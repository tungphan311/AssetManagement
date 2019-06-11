using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RetailPayments.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Retails;
using GWebsite.AbpZeroTemplate.Application.Share.Retails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Retails
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class RetailAppService : GWebsiteAppServiceBase, IRetailAppService
    {
        private readonly IRepository<Retail> retailRepository;
        private readonly IRepository<RetailPayment> repository;

        public RetailAppService(IRepository<Retail> retailRepository, IRepository<RetailPayment> repository)
        {
            this.retailRepository = retailRepository;
            this.repository = repository;
        }

        #region Public Method

        public void CreateOrEditRetail(RetailInput retailInput)
        {
            if (retailInput.Id == 0)
            {
                Create(retailInput);
            }
            else
            {
                Update(retailInput);
            }
        }

        public void DeleteRetail(int id)
        {
            var retailEntity = retailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (retailEntity != null)
            {
                retailEntity.IsDelete = true;
                retailRepository.Update(retailEntity);

                var paymentList = repository.GetAll().Where(x => !x.IsDelete && x.RetailId == id);
                foreach(var payment in paymentList)
                {
                    payment.IsDelete = true;
                    SetAuditEdit(payment);
                    repository.Update(payment);
                }

                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RetailInput GetRetailForEdit(int id)
        {
            var retailEntity = retailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (retailEntity == null)
            {
                return null;
            }

            var retailInput = ObjectMapper.Map<RetailInput>(retailEntity);

            var paymentList = repository.GetAll().Where(x => !x.IsDelete && x.RetailId == id);
            retailInput.Payments = paymentList.Select(x => ObjectMapper.Map<RetailPaymentInput>(x)).ToList();

            return retailInput;
        }

        public RetailForViewDto GetRetailForView(int id)
        {
            var retailEntity = retailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (retailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RetailForViewDto>(retailEntity);
        }

        public PagedResultDto<RetailDto> GetRetails(RetailFilter input)
        {
            var query = retailRepository.GetAll().Where(x => !x.IsDelete);

            // filter by merchandise ID
            if (input.MerchandiseID != 0)
            {
                query = query.Where(x => x.MerchandiseID == input.MerchandiseID);
            }
            // filter by vendor ID
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
            return new PagedResultDto<RetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(RetailInput retailInput)
        {
            var retailEntity = ObjectMapper.Map<Retail>(retailInput);
            SetAuditInsert(retailEntity);
            var id = retailRepository.InsertAndGetId(retailEntity);

            foreach(var payment in retailInput.Payments)
            {
                payment.RetailId = id;
                var entity = ObjectMapper.Map<RetailPayment>(payment);
                SetAuditInsert(entity);
                repository.Insert(entity);
            }

            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(RetailInput retailInput)
        {
            var retailEntity = retailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == retailInput.Id);
            if (retailEntity == null)
            {
            }
            ObjectMapper.Map(retailInput, retailEntity);
            SetAuditEdit(retailEntity);
            retailRepository.Update(retailEntity);

            var paymentList = repository.GetAll().Where(x => !x.IsDelete && x.RetailId == retailInput.Id);
            foreach(var payment in paymentList)
            {
                payment.IsDelete = true;
                SetAuditEdit(payment);
                repository.Update(payment);
            }

            foreach(var payment in retailInput.Payments)
            {
                payment.RetailId = retailInput.Id;
                var entity = ObjectMapper.Map<RetailPayment>(payment);
                SetAuditInsert(entity);
                repository.Insert(entity);
            }

            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}