using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Invoices;
using GWebsite.AbpZeroTemplate.Application.Share.Invoices.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Invoices
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class InvoiceAppService : GWebsiteAppServiceBase, IInvoiceAppService
    {
        private readonly IRepository<Invoice> invoiceRepository;

        public InvoiceAppService(IRepository<Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        #region Public Method

        public void CreateOrEditInvoice(InvoiceInput invoiceInput)
        {
            if (invoiceInput.Id == 0)
            {
                Create(invoiceInput);
            }
            else
            {
                Update(invoiceInput);
            }
        }

        public void DeleteInvoice(int id)
        {
            var invoiceEntity = invoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (invoiceEntity != null)
            {
                invoiceEntity.IsDelete = true;
                invoiceRepository.Update(invoiceEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public InvoiceInput GetInvoiceForEdit(int id)
        {
            var invoiceEntity = invoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (invoiceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InvoiceInput>(invoiceEntity);
        }

        public InvoiceForViewDto GetInvoiceForView(int id)
        {
            var invoiceEntity = invoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (invoiceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InvoiceForViewDto>(invoiceEntity);
        }

        public PagedResultDto<InvoiceDto> GetInvoices(InvoiceFilter input)
        {
            var query = invoiceRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
            }
            if (input.Date != null)
            {
                query = query.Where(x => x.Date==input.Date);
            }
            if (input.StaffID != null)
            {
                query = query.Where(x => x.StaffID == input.StaffID);
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
            return new PagedResultDto<InvoiceDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<InvoiceDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(InvoiceInput invoiceInput)
        {
            var invoiceEntity = ObjectMapper.Map<Invoice>(invoiceInput);
            SetAuditInsert(invoiceEntity);
            invoiceRepository.Insert(invoiceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(InvoiceInput invoiceInput)
        {
            var invoiceEntity = invoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == invoiceInput.Id);
            if (invoiceEntity == null)
            {
            }
            ObjectMapper.Map(invoiceInput, invoiceEntity);
            SetAuditEdit(invoiceEntity);
            invoiceRepository.Update(invoiceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
