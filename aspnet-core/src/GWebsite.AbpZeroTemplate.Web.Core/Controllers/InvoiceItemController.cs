using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems;
using GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InvoiceItemController : GWebsiteControllerBase
    {
        private readonly IInvoiceItemAppService invoiceitemAppService;

        public InvoiceItemController(IInvoiceItemAppService invoiceitemAppService)
        {
            this.invoiceitemAppService = invoiceitemAppService;
        }

        [HttpGet]
        public PagedResultDto<InvoiceItemDto> GetInvoiceItemsByFilter(InvoiceItemFilter invoiceitemFilter)
        {
            return invoiceitemAppService.GetInvoiceItems(invoiceitemFilter);
        }

        [HttpGet]
        public InvoiceItemInput GetInvoiceItemForEdit(int id)
        {
            return invoiceitemAppService.GetInvoiceItemForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditInvoiceItem([FromBody] InvoiceItemInput input)
        {
            invoiceitemAppService.CreateOrEditInvoiceItem(input);
        }

        [HttpDelete("{id}")]
        public void DeleteInvoiceItem(int id)
        {
            invoiceitemAppService.DeleteInvoiceItem(id);
        }

        [HttpGet]
        public InvoiceItemForViewDto GetInvoiceItemForView(int id)
        {
            return invoiceitemAppService.GetInvoiceItemForView(id);
        }
    }
}
