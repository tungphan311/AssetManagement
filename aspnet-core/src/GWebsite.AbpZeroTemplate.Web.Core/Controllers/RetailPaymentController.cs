using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RetailPayments;
using GWebsite.AbpZeroTemplate.Application.Share.RetailPayments.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RetailPaymentController : GWebsiteControllerBase
    {
        private readonly IRetailPaymentAppService retailpaymentAppService;

        public RetailPaymentController(IRetailPaymentAppService retailpaymentAppService)
        {
            this.retailpaymentAppService = retailpaymentAppService;
        }

        [HttpGet]
        public PagedResultDto<RetailPaymentDto> GetRetailPaymentsByFilter(RetailPaymentFilter retailpaymentFilter)
        {
            return retailpaymentAppService.GetRetailPayments(retailpaymentFilter);
        }
        [HttpGet]
        public RetailPaymentInput GetRetailPaymentForEdit(int id)
        {
            return retailpaymentAppService.GetRetailPaymentForEdit(id);
        }


        [HttpPost]
        public void CreateOrEditRetailPayment([FromBody] RetailPaymentInput input)
        {
            retailpaymentAppService.CreateOrEditRetailPayment(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRetailPayment(int id)
        {
            retailpaymentAppService.DeleteRetailPayment(id);
        }

        [HttpGet]
        public RetailPaymentForViewDto GetRetailPaymentForView(int id)
        {
            return retailpaymentAppService.GetRetailPaymentForView(id);
        }
    }
}
