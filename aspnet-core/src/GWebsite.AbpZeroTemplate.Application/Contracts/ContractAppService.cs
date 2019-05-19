using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Contracts
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ContractAppService : GWebsiteAppServiceBase, IContractAppService
    {
        private readonly IRepository<Contract> contractRepository;

        public ContractAppService(IRepository<Contract> contractRepository)
        {
            this.contractRepository = contractRepository;
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
            if (input.Id != 0)
            {
                query = query.Where(x => x.Id == input.Id);
            }

            //filter by name 
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name.ToLower()));
            }

            if (input.DeliveryTime != null)
            {
                //xu ly lay theo date time tinh sau
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
            contractRepository.Insert(contractEntity);
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