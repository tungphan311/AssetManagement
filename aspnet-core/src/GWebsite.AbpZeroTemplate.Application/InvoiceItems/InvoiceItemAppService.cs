using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems;
using GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.InvoiceItems
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class InvoiceItemAppService : GWebsiteAppServiceBase, IInvoiceItemAppService
    {
        private readonly IRepository<InvoiceItem> invoiceitemRepository;

        public InvoiceItemAppService(IRepository<InvoiceItem> invoiceitemRepository)
        {
            this.invoiceitemRepository = invoiceitemRepository;
        }

        #region Public Method

        public void CreateOrEditInvoiceItem(InvoiceItemInput invoiceitemInput)
        {
            if (invoiceitemInput.Id == 0)
            {
                Create(invoiceitemInput);
            }
            else
            {
                Update(invoiceitemInput);
            }
        }

        public void DeleteInvoiceItem(int id)
        {
            var invoiceitemEntity = invoiceitemRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (invoiceitemEntity != null)
            {
                invoiceitemEntity.IsDelete = true;
                invoiceitemRepository.Update(invoiceitemEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public InvoiceItemInput GetInvoiceItemForEdit(int id)
        {
            var invoiceitemEntity = invoiceitemRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (invoiceitemEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InvoiceItemInput>(invoiceitemEntity);
        }

        public InvoiceItemForViewDto GetInvoiceItemForView(int id)
        {
            var invoiceitemEntity = invoiceitemRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (invoiceitemEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InvoiceItemForViewDto>(invoiceitemEntity);
        }

        public PagedResultDto<InvoiceItemDto> GetInvoiceItems(InvoiceItemFilter input)
        {
            var query = invoiceitemRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.InvoiceID != null)
            {
                query = query.Where(x => x.InvoiceID==input.InvoiceID);
            }
            if (input.AssetID != null)
            {
                query = query.Where(x => x.AssetID == input.AssetID);
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
            return new PagedResultDto<InvoiceItemDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<InvoiceItemDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(InvoiceItemInput invoiceitemInput)
        {
            var invoiceitemEntity = ObjectMapper.Map<InvoiceItem>(invoiceitemInput);
            SetAuditInsert(invoiceitemEntity);
            invoiceitemRepository.Insert(invoiceitemEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(InvoiceItemInput invoiceitemInput)
        {
            var invoiceitemEntity = invoiceitemRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == invoiceitemInput.Id);
            if (invoiceitemEntity == null)
            {
            }
            ObjectMapper.Map(invoiceitemInput, invoiceitemEntity);
            SetAuditEdit(invoiceitemEntity);
            invoiceitemRepository.Update(invoiceitemEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
