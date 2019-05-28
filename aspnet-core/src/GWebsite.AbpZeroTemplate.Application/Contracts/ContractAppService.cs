using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Contracts
{
    public class ContractAppService : GWebsiteAppServiceBase, IContractAppService
    {
        private readonly IRepository<Contract> contractRepository;

        public ContractAppService(IRepository<Contract> contractRepository)
        {
            this.contractRepository = contractRepository;
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
            return ObjectMapper.Map<ContractInput>(ContractEntity);
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
        private void Create(ContractInput ContractInput)
        {
            System.Console.WriteLine("ContractInput: " + ContractInput.Code.ToString());
            try
            {
                var ContractEntity = ObjectMapper.Map<Contract>(ContractInput);
                if (ContractEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(ContractEntity);
                contractRepository.Insert(ContractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contract_Edit)]
        private void Update(ContractInput ContractInput)
        {
            var ContractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ContractInput.Id);
            if (ContractEntity == null)
            {
            }
            ObjectMapper.Map(ContractInput, ContractEntity);
            SetAuditEdit(ContractEntity);
            contractRepository.Update(ContractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
