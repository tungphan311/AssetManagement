using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Invoices.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Invoices
{
    public interface IInvoiceAppService
    {
        void CreateOrEditInvoice(InvoiceInput customerInput);
        InvoiceInput GetInvoiceForEdit(int id);
        void DeleteInvoice(int id);
        PagedResultDto<InvoiceDto> GetInvoices(InvoiceFilter input);
        InvoiceForViewDto GetInvoiceForView(int id);
    }
}
