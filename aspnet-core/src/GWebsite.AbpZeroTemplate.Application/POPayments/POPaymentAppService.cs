using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.POPayments;
using GWebsite.AbpZeroTemplate.Application.Share.POPayments.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.POPayments
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class POPaymentAppService : GWebsiteAppServiceBase, IPOPaymentAppService
    {
        private readonly IRepository<POPayment> popaymentRepository;

        public POPaymentAppService(IRepository<POPayment> popaymentRepository)
        {
            this.popaymentRepository = popaymentRepository;
        }

        #region Public Method

        public void CreateOrEditPOPayment(POPaymentInput popaymentInput)
        {
            if (popaymentInput.Id == 0)
            {
                Create(popaymentInput);
            }
            else
            {
                Update(popaymentInput);
            }
        }

        public void DeletePOPayment(int id)
        {
            var popaymentEntity = popaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (popaymentEntity != null)
            {
                popaymentEntity.IsDelete = true;
                popaymentRepository.Update(popaymentEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public POPaymentInput GetPOPaymentForEdit(int id)
        {
            var popaymentEntity = popaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (popaymentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<POPaymentInput>(popaymentEntity);
        }


        public PagedResultDto<POPaymentDto> GetPOPayments(POPaymentFilter input)
        {
            var query = popaymentRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.POID != 0)
            {
                query = query.Where(x => x.POID == input.POID);
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
            return new PagedResultDto<POPaymentDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<POPaymentDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(POPaymentInput popaymentInput)
        {
            var popaymentEntity = ObjectMapper.Map<POPayment>(popaymentInput);
            SetAuditInsert(popaymentEntity);
            popaymentRepository.Insert(popaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(POPaymentInput popaymentInput)
        {
            var popaymentEntity = popaymentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == popaymentInput.Id);
            if (popaymentEntity == null)
            {
            }
            ObjectMapper.Map(popaymentInput, popaymentEntity);
            SetAuditEdit(popaymentEntity);
            popaymentRepository.Update(popaymentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
