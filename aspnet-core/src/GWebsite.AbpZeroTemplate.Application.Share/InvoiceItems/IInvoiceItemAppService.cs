using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems
{
    public interface IInvoiceItemAppService
    {
        void CreateOrEditInvoiceItem(InvoiceItemInput customerInput);
        InvoiceItemInput GetInvoiceItemForEdit(int id);
        void DeleteInvoiceItem(int id);
        PagedResultDto<InvoiceItemDto> GetInvoiceItems(InvoiceItemFilter input);
        InvoiceItemForViewDto GetInvoiceItemForView(int id);
    }
}
