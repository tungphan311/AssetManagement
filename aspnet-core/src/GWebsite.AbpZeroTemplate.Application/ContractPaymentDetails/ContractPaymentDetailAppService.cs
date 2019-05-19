using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ContractPaymentDetails
{
    public class ContractPaymentDetailAppService : GWebsiteAppServiceBase, IContractPaymentDetailAppService
    {
        private readonly IRepository<ContractPaymentDetail> contractPaymentDetailRepository;

        public ContractPaymentDetailAppService(IRepository<ContractPaymentDetail> contractPaymentDetailRepository)
        {
            this.contractPaymentDetailRepository = contractPaymentDetailRepository;
        }

        #region Public Method

        public void CreateOrEditContractPaymentDetail(ContractPaymentDetailInput ContractPaymentDetailInput)
        {

            if (ContractPaymentDetailInput.Id == 0)
            {
                Create(ContractPaymentDetailInput);
            }
            else
            {
                Update(ContractPaymentDetailInput);
            }
        }

        public void DeleteContractPaymentDetail(int id)
        {
            var ContractPaymentDetailEntity = contractPaymentDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
            if (ContractPaymentDetailEntity != null)
            {
                //ContractPaymentDetailEntity.IsDelete = true;
                contractPaymentDetailRepository.Delete(ContractPaymentDetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public void DeleteMultiContractPaymentDetail(int contractId)
        {
            contractPaymentDetailRepository.DeleteAsync(x => x.ContractId == contractId);
        }

        public ContractPaymentDetailInput GetContractPaymentDetailForEdit(int id)
        {
            var ContractPaymentDetailEntity = contractPaymentDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
            if (ContractPaymentDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractPaymentDetailInput>(ContractPaymentDetailEntity);
        }

        public ContractPaymentDetailForViewDto GetContractPaymentDetailForView(int id)
        {
            try
            {
                var ContractPaymentDetailEntity = contractPaymentDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
                if (ContractPaymentDetailEntity == null)
                {
                    Console.WriteLine("ContractPaymentDetail with id=" + id.ToString() + " is null");
                    return null;
                }
                return ObjectMapper.Map<ContractPaymentDetailForViewDto>(ContractPaymentDetailEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception ContractPaymentDetail for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<ContractPaymentDetailDto> GetContractPaymentDetails(ContractPaymentDetailFilter input)
        {
            var query = contractPaymentDetailRepository.GetAll()/*.Where(x => !x.IsDelete);*/;

            // filter by value

            query = query.Where(x => x.ContractId == input.ContractId);

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ContractPaymentDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractPaymentDetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractPaymentDetail_Create)]
        private void Create(ContractPaymentDetailInput ContractPaymentDetailInput)
        {
            try
            {
                var ContractPaymentDetailEntity = ObjectMapper.Map<ContractPaymentDetail>(ContractPaymentDetailInput);
                if (ContractPaymentDetailEntity == null) System.Console.WriteLine("null: ");
                //SetAuditInsert(ContractPaymentDetailEntity);
                contractPaymentDetailRepository.Insert(ContractPaymentDetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractPaymentDetail_Edit)]
        private void Update(ContractPaymentDetailInput ContractPaymentDetailInput)
        {
            var ContractPaymentDetailEntity = contractPaymentDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == ContractPaymentDetailInput.Id);
            if (ContractPaymentDetailEntity == null)
            {
            }
            ObjectMapper.Map(ContractPaymentDetailInput, ContractPaymentDetailEntity);
            //SetAuditEdit(ContractPaymentDetailEntity);
            contractPaymentDetailRepository.Update(ContractPaymentDetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
