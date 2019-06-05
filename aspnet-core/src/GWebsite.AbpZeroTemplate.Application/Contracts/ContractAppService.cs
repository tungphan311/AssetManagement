using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductContracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Web.Core.ProductContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Contracts
{
    public class ContractAppService : GWebsiteAppServiceBase, IContractAppService
    {
        private readonly IRepository<Contract> contractRepository;
        private readonly IRepository<ContractPaymentDetail> paymentRepository;
        private readonly IRepository<ProductContract> productContractRepository;
        private readonly IRepository<Product> productRepository;
        public ContractAppService(IRepository<Contract> contractRepository, IRepository<ProductContract> productContractRepository, IRepository<Product> productRepository, IRepository<ContractPaymentDetail> paymentRepository)
        {
            this.contractRepository = contractRepository;
            this.paymentRepository = paymentRepository;
            this.productContractRepository = productContractRepository;
            this.productRepository = productRepository;
        }

        #region Public Method

        public void CreateOrEditContract(ContractInput ContractInput)
        {
            if (ContractInput.BidId != null && ContractInput.BidId == 0)
            {
                ContractInput.BidId = null;
            }
            if (ContractInput.ProviderId != null && ContractInput.ProviderId == 0)
            {
                ContractInput.ProviderId = null;
            }

            if (ContractInput.Id == 0)
            {
                Create(ContractInput);
            }
            else
            {
                Update(ContractInput);
            }
        }

        public void DeleteContract(int id)
        {
            var ContractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractEntity != null)
            {
                ContractEntity.IsDelete = true;
                contractRepository.Update(ContractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractInput GetContractForEdit(int id)
        {
            var ContractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractEntity == null)
            {
                return null;
            }


            var contractInput = ObjectMapper.Map<ContractInput>(ContractEntity);

            var productContracts = ObjectMapper.Map<List<ProductContractInput>>(productContractRepository.GetAll().Where(x => x.ContractId == ContractEntity.Id && x.IsDelete == false).ToList());
            if (productContracts.Count() > 0)
            {
                for (int i = 0; i < productContracts.Count(); i++)
                {
                    var prod = ObjectMapper.Map<ProductInput>(productRepository.FirstOrDefault(x => x.Id == productContracts.ElementAt(i).ProductId && x.IsDelete == false));
                    if (prod == null) prod = new ProductInput();
                    productContracts.ElementAt(i).Product = prod;
                }
            }
            contractInput.ProductContracts = (productContracts);


            var payments = ObjectMapper.Map<List<ContractPaymentDetailInput>>(paymentRepository.GetAll().Where(x => x.ContractId == ContractEntity.Id && x.IsDelete == false).ToList());
            contractInput.ContractPaymentDetails = (payments);

            return (contractInput);
        }

        public ContractForViewDto GetContractForView(int id)
        {
            try
            {
                var ContractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
                if (ContractEntity == null)
                {
                    Console.WriteLine("Contract with id=" + id.ToString() + " is null");
                    return null;
                }
                return ObjectMapper.Map<ContractForViewDto>(ContractEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception Contract for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<ContractDto> GetContracts(ContractFilter input)
        {
            var query = contractRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(input.Name));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ContractDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contract_Create)]
        private void Create(ContractInput contractInput)
        {
            System.Console.WriteLine("ContractInput: " + contractInput.ToString());
            try
            {
                var ContractEntity = ObjectMapper.Map<Contract>(contractInput);
                if (ContractEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(ContractEntity);
                ContractEntity.ProductContracts = null;
                var contractId = contractRepository.InsertAndGetId(ContractEntity);

                if (contractInput.ProductContracts != null && contractInput.ProductContracts.Count() > 0)
                {
                    ContractEntity.ProductContracts = new List<ProductContract>();
                    foreach (var item in contractInput.ProductContracts)
                    {
                        //item.Id = 0;
                        //item.ContractId = contractId;
                        //item.Product = null;
                        var pcItem = new ProductContract();
                        pcItem.ContractId = contractId;
                        pcItem.ProductId = item.ProductId;
                        pcItem.Amount = item.Amount;
                        pcItem.Price = item.Price;
                        pcItem.Description = item.Description;
                        pcItem.Product = null;

                        ContractEntity.ProductContracts.Add(pcItem);
                    }

                }

                if (contractInput.ContractPaymentDetails != null && contractInput.ContractPaymentDetails.Count() > 0)
                {
                    foreach (var item in contractInput.ContractPaymentDetails)
                    {
                        var paymentItem = new ContractPaymentDetail();
                        paymentItem.ContractId = contractId;
                        paymentItem.InstallmentNumber = item.InstallmentNumber;
                        paymentItem.ExpectedDate = item.ExpectedDate;
                        paymentItem.Price = item.Price;
                        paymentItem.Description = item.Description;
                        paymentItem.Note = item.Note;
                        paymentItem.Contract = null;

                        paymentRepository.Insert(paymentItem);
                    }
                }
                contractRepository.Update(ContractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contract_Edit)]
        private void Update(ContractInput contractInput)
        {
            var ContractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == contractInput.Id);
            if (ContractEntity == null)
            {
            }
            ObjectMapper.Map(contractInput, ContractEntity);
            SetAuditEdit(ContractEntity);
            ContractEntity.ProductContracts = new List<ProductContract>();
            //
            var contractId = ContractEntity.Id;

            productContractRepository.Delete(x => x.ContractId == contractId);

            if (contractInput.ProductContracts != null && contractInput.ProductContracts.Count() > 0)
            {

                foreach (var item in contractInput.ProductContracts)
                {
                    //item.Id = 0;
                    //item.ContractId = contractId;
                    //item.Product = null;
                    var pcItem = new ProductContract();
                    pcItem.ContractId = contractId;
                    pcItem.ProductId = item.ProductId;
                    pcItem.Amount = item.Amount;
                    pcItem.Price = item.Price;
                    pcItem.Description = item.Description;
                    pcItem.Product = null;

                    productContractRepository.Insert(pcItem);
                }

            }

            paymentRepository.Delete(x => x.ContractId == contractId);
            if (contractInput.ContractPaymentDetails != null && contractInput.ContractPaymentDetails.Count() > 0)
            {
                foreach (var item in contractInput.ContractPaymentDetails)
                {
                    var paymentItem = new ContractPaymentDetail();
                    paymentItem.ContractId = contractId;
                    paymentItem.InstallmentNumber = item.InstallmentNumber;
                    paymentItem.ExpectedDate = item.ExpectedDate;
                    paymentItem.Price = item.Price;
                    paymentItem.Description = item.Description;
                    paymentItem.Note = item.Note;
                    paymentItem.Contract = null;

                    paymentRepository.Insert(paymentItem);
                }
            }

            contractRepository.Update(ContractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
