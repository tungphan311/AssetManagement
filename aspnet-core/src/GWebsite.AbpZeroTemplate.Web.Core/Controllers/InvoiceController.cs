using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Invoices;
using GWebsite.AbpZeroTemplate.Application.Share.Invoices.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InvoiceController : GWebsiteControllerBase
    {
        private readonly IInvoiceAppService invoiceAppService;

        public InvoiceController(IInvoiceAppService invoiceAppService)
        {
            this.invoiceAppService = invoiceAppService;
        }
        [HttpDelete("{id}")]
        public void DeleteInvoice(int id)
        {
            invoiceAppService.DeleteInvoice(id);
        }
        //không add được phần dưới đây vì gây lỗi trên swagger do có liên quan tới datetime, không biết fix sao nữa
        /* 
        [HttpGet]
        public PagedResultDto<InvoiceDto> GetInvoicesByFilter(InvoiceFilter invoiceFilter)
        {
            return invoiceAppService.GetInvoices(invoiceFilter);
        }
        [HttpGet]
        public InvoiceInput GetInvoiceForEdit(int id)
        {
            return invoiceAppService.GetInvoiceForEdit(id);
        }
        [HttpPost]
        public void CreateOrEditInvoice([FromBody] InvoiceInput input)
        {
            invoiceAppService.CreateOrEditInvoice(input);
        }
        [HttpGet]
        public InvoiceForViewDto GetInvoiceForView(int id)
        {
            return invoiceAppService.GetInvoiceForView(id);
        }
        */
    }
}
