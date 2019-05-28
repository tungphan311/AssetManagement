using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Contracts
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ContractAppService : GWebsiteAppServiceBase, IContractAppService
    {
        private readonly IRepository<Contract> contractRepository;
        private readonly IRepository<ContractDetail> detailRepository;

        public ContractAppService(IRepository<Contract> contractRepository, IRepository<ContractDetail> detailRepository)
        {
            this.contractRepository = contractRepository;
            this.detailRepository = detailRepository;
        }

        #region Public Method

        public void CreateOrEditContract(ContractInput contractInput)
        {
            if (contractInput.Id == 0)
            {
                Create(contractInput);
            }
            else
            {
                Update(contractInput);
            }
        }

        public void DeleteContract(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity != null)
            {
                contractEntity.IsDelete = true;
                contractRepository.Update(contractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractInput GetContractForEdit(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractInput>(contractEntity);
        }

        public ContractForViewDto GetContractForView(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractForViewDto>(contractEntity);
        }

        public PagedResultDto<ContractDto> GetContracts(ContractFilter input)
        {
            var query = contractRepository.GetAll().Where(x => !x.IsDelete);

            // filter by Id
            if (input.ContractID != null)
            {
                query = query.Where(x => x.ContractID.ToLower().Contains(input.ContractID.ToLower()));
            }

            //filter by name 
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name.ToLower()));
            }

            if (input.DeliveryTime != null)
            {
                DateTime dt = DateTime.ParseExact(input.DeliveryTime, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                dt = dt.ToUniversalTime();
                query = query.Where(x => x.DeliveryTime.DayOfYear == dt.DayOfYear);

            }

            // filter by BriefcaseID
            if (input.BriefcaseID != 0)
            {
                query = query.Where(x => x.BriefcaseID == input.BriefcaseID);
            }

            // filter by VendorID
            if (input.VendorID != 0)
            {
                query = query.Where(x => x.VendorID == input.VendorID);
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

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(ContractInput contractInput)
        {
            var contractEntity = ObjectMapper.Map<Contract>(contractInput);
            SetAuditInsert(contractEntity);
            var id = contractRepository.InsertAndGetId(contractEntity);

            //foreach(var product in contractInput.Products)
            //{
            //    // insert vo bang ProductContract co productId va contractId
            //    ContractDetailInput detailInput = new ContractDetailInput(id, product.Id, product.MerCode, product.MerName, product.Quantity, product.Price, product.Note);
            //    var detailEntity = ObjectMapper.Map<ContractDetail>(detailInput);
            //    SetAuditInsert(detailEntity);
            //    detailRepository.Insert(detailEntity);
            //}

            //ContractDetailInput detailInput = new ContractDetailInput(id, 1, "CODE", "NAME", 1, 100, "NOTE");
            //var detailEntity = ObjectMapper.Map<ContractDetail>(detailInput);
            //SetAuditInsert(detailEntity);
            //detailRepository.Insert(detailEntity);

            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(ContractInput contractInput)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == contractInput.Id);
            if (contractEntity == null)
            {
            }
            ObjectMapper.Map(contractInput, contractEntity);
            SetAuditEdit(contractEntity);
            contractRepository.Update(contractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}