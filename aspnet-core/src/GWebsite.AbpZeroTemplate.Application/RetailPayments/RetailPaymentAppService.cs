using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RetailPayments;
using GWebsite.AbpZeroTemplate.Application.Share.RetailPayments.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.RetailPayments
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class RetailPaymentAppService : GWebsiteAppServiceBase, IRetailPaymentAppService
    {
        private readonly IRepository<RetailPayment> retailPaymentRepository;

        public RetailPaymentAppService(IRepository<RetailPayment> retailPaymentRepository)
        {
            this.retailPaymentRepository = retailPaymentRepository;
        }

        #region Public Method

        public void CreateOrEditRetailPayment(RetailPaymentInput retailPaymentInput)
        {
            if (retailPaymentInput.Id == 0)
            {
                Create(retailPaymentInput);
            }
            else
            {
                Update(retailPaymentInput);
            }
        }

        public void DeleteRetailPayment(int id)
        {
            var retailPaymentEntity = retailPaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (retailPaymentEntity != null)
            {
                retailPaymentEntity.IsDelete = true;
                retailPaymentRepository.Update(retailPaymentEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RetailPaymentInput GetRetailPaymentForEdit(int id)
        {
            var retailPaymentEntity = retailPaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (retailPaymentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RetailPaymentInput>(retailPaymentEntity);
        }

        public RetailPaymentForViewDto GetRetailPaymentForView(int id)
        {
            var retailPaymentEntity = retailPaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (retailPaymentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RetailPaymentForViewDto>(retailPaymentEntity);
        }

        public PagedResultDto<RetailPaymentDto> GetRetailPayments(RetailPaymentFilter input)
        {
            var query = retailPaymentRepository.GetAll().Where(x => !x.IsDelete);

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<RetailPaymentDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RetailPaymentDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(RetailPaymentInput retailPaymentInput)
        {
            var retailPaymentEntity = ObjectMapper.Map<RetailPayment>(retailPaymentInput);
            SetAuditInsert(retailPaymentEntity);
            retailPaymentRepository.Insert(retailPaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(RetailPaymentInput retailPaymentInput)
        {
            var retailPaymentEntity = retailPaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == retailPaymentInput.Id);
            if (retailPaymentEntity == null)
            {
            }
            ObjectMapper.Map(retailPaymentInput, retailPaymentEntity);
            SetAuditEdit(retailPaymentEntity);
            retailPaymentRepository.Update(retailPaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}