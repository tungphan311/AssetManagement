using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ContractDetails
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ContractDetailAppService : GWebsiteAppServiceBase, IContractDetailAppService
    {
        private readonly IRepository<ContractDetail> contractdetailRepository;

        public ContractDetailAppService(IRepository<ContractDetail> contractdetailRepository)
        {
            this.contractdetailRepository = contractdetailRepository;
        }

        #region Public Method

        public void CreateOrEditContractDetail(ContractDetailInput contractdetailInput)
        {
            if (contractdetailInput.Id == 0)
            {
                Create(contractdetailInput);
            }
            else
            {
                Update(contractdetailInput);
            }
        }

        public void DeleteContractDetail(int id)
        {
            var contractdetailEntity = contractdetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractdetailEntity != null)
            {
                contractdetailEntity.IsDelete = true;
                contractdetailRepository.Update(contractdetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractDetailInput GetContractDetailForEdit(int id)
        {
            var contractdetailEntity = contractdetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractdetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractDetailInput>(contractdetailEntity);
        }


        public PagedResultDto<ContractDetailDto> GetContractDetails(ContractDetailFilter input)
        {
            var query = contractdetailRepository.GetAll().Where(x => !x.IsDelete);

            query = query.Where(x => x.ContractID == input.ContractID);

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ContractDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractDetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(ContractDetailInput contractdetailInput)
        {
            var contractdetailEntity = ObjectMapper.Map<ContractDetail>(contractdetailInput);
            SetAuditInsert(contractdetailEntity);
            contractdetailRepository.Insert(contractdetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(ContractDetailInput contractdetailInput)
        {
            var contractdetailEntity = contractdetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == contractdetailInput.Id);
            if (contractdetailEntity == null)
            {
            }
            ObjectMapper.Map(contractdetailInput, contractdetailEntity);
            SetAuditEdit(contractdetailEntity);
            contractdetailRepository.Update(contractdetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
