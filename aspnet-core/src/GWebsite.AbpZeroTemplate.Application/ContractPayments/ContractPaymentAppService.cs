using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ContractPayments
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ContractPaymentAppService : GWebsiteAppServiceBase, IContractPaymentAppService
    {
        private readonly IRepository<ContractPayment> contractpaymentRepository;

        public ContractPaymentAppService(IRepository<ContractPayment> contractpaymentRepository)
        {
            this.contractpaymentRepository = contractpaymentRepository;
        }

        #region Public Method

        public void CreateOrEditContractPayment(ContractPaymentInput contractpaymentInput)
        {
            if (contractpaymentInput.Id == 0)
            {
                Create(contractpaymentInput);
            }
            else
            {
                Update(contractpaymentInput);
            }
        }

        public void DeleteContractPayment(int id)
        {
            var contractpaymentEntity = contractpaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractpaymentEntity != null)
            {
                contractpaymentEntity.IsDelete = true;
                contractpaymentRepository.Update(contractpaymentEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractPaymentInput GetContractPaymentForEdit(int id)
        {
            var contractpaymentEntity = contractpaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractpaymentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractPaymentInput>(contractpaymentEntity);
        }


        public PagedResultDto<ContractPaymentDto> GetContractPayments(ContractPaymentFilter input)
        {
            var query = contractpaymentRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.ContractID != 0)
            {
                query = query.Where(x => x.ContractID == input.ContractID);
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
            return new PagedResultDto<ContractPaymentDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractPaymentDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(ContractPaymentInput contractpaymentInput)
        {
            var contractpaymentEntity = ObjectMapper.Map<ContractPayment>(contractpaymentInput);
            SetAuditInsert(contractpaymentEntity);
            contractpaymentRepository.Insert(contractpaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(ContractPaymentInput contractpaymentInput)
        {
            var contractpaymentEntity = contractpaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == contractpaymentInput.Id);
            if (contractpaymentEntity == null)
            {
            }
            ObjectMapper.Map(contractpaymentInput, contractpaymentEntity);
            SetAuditEdit(contractpaymentEntity);
            contractpaymentRepository.Update(contractpaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
