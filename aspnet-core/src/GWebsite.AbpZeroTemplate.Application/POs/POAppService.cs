using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.POs;
using GWebsite.AbpZeroTemplate.Application.Share.POs.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.POPayments.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.POs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class POAppService : GWebsiteAppServiceBase, IPOAppService
    {
        private readonly IRepository<PO> poRepository;
        private readonly IRepository<Vendor> vendorRepository;
        private readonly IRepository<Contract> contractRepository;
        private readonly IRepository<POPayment> paymentRepository;


        public POAppService(IRepository<PO> repository, IRepository<Vendor> vendorRepository, IRepository<Contract> contractRepository, IRepository<POPayment> paymentRepository)
        {
            poRepository = repository;
            this.vendorRepository = vendorRepository;
            this.contractRepository = contractRepository;
            this.paymentRepository = paymentRepository;
        }

        #region public method

        public void CreateOrEditPO(POInput input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Update(input);
            }
        }

        public void DeletePO(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDelete = true;
                poRepository.Update(entity);
                CurrentUnitOfWork.SaveChanges();

                // xoá contract payment ứng với PO này
                var paymentList = paymentRepository.GetAll().Where(x => !x.IsDelete && x.POID == id);
                foreach (var payment in paymentList)
                {
                    payment.IsDelete = true;
                    SetAuditEdit(payment);
                    paymentRepository.Update(payment);
                }
            }
        }

        public POInput GetPOForEdit(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }

            var poInput = ObjectMapper.Map<POInput>(entity);
           
            var paymentList = paymentRepository.GetAll().Where(x => !x.IsDelete && x.POID == id);
            poInput.Payments = paymentList.Select(x => ObjectMapper.Map<POPaymentInput>(x)).ToList();

            return poInput;
        }

        public POForViewDto GetPOForView(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<POForViewDto>(entity);
        }

        public PagedResultDto<PODto> GetPOs(POFilter input)
        {
            var query = poRepository.GetAll().Where(x => !x.IsDelete);
            var contract = contractRepository.GetAll().Where(x => !x.IsDelete);
            var vendor = vendorRepository.GetAll().Where(x => !x.IsDelete);

            if (input.POID != null)
            {
                query = query.Where(x => x.POID.ToLower().Contains(input.POID.ToLower()));
            }

            if (input.OrderName != null)
            {
                query = query.Where(x => x.OrderName.ToLower().Contains(input.OrderName.ToLower()));
            }

            if (input.ContractID != null)
            {
                var contracts = contract.Where(x => x.Name.ToLower().Contains(input.ContractID.ToLower())).ToList();

                query = query.Where(x => isExist(contracts, x.ContractID));
            }

            if (input.VendorID != null)
            {
                var vendors = vendor.Where(x => x.Name.ToLower().Contains(input.VendorID.ToLower())).ToList();

                query = query.Where(x => isVendorExist(vendors, x.VendorID));
            }

            if (input.Type == "in")
            {
                query = query.Where(x => x.ContractID != 0);
            }
            else if (input.Type == "out")
            {
                query = query.Where(x => x.ContractID == 0);
            }

            var totalCount = query.Count();

            // sort
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<PODto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PODto>(item)).ToList());
        }

        #endregion

        #region private method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(POInput poInput)
        {
            var entity = ObjectMapper.Map<PO>(poInput);
            SetAuditInsert(entity);
            var id = poRepository.InsertAndGetId(entity);

            foreach (var payment in poInput.Payments)
            {
                payment.POID = id;
                var paymentEntity = ObjectMapper.Map<POPayment>(payment);
                SetAuditInsert(paymentEntity);
                paymentRepository.Insert(paymentEntity);
            }

            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(POInput poInput)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == poInput.Id);
            if (entity == null)
            {

            }
            ObjectMapper.Map(poInput, entity);
            SetAuditEdit(entity);
            poRepository.Update(entity);

            // xoá hết payment đang có trước 
            var paymentList = paymentRepository.GetAll().Where(x => !x.IsDelete && x.POID == poInput.Id);

            foreach (var payment in paymentList)
            {
                payment.IsDelete = true;
                SetAuditEdit(payment);
                paymentRepository.Update(payment);
            }

            if (poInput.Payments != null)
            {
                foreach (var payment in poInput.Payments)
                {
                    payment.POID = poInput.Id;
                    var paymentEntity = ObjectMapper.Map<POPayment>(payment);
                    SetAuditInsert(paymentEntity);
                    paymentRepository.Insert(paymentEntity);
                }
            }

            CurrentUnitOfWork.SaveChanges();
        }

        private bool isExist(List<Contract> contracts, int id)
        {
            foreach(var contract in contracts)
            {
                if (contract.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isVendorExist(List<Vendor> vendors, int id)
        {
            foreach (var vendor in vendors)
            {
                if (vendor.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
