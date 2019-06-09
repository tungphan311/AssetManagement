using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PurchaseOrderController : GWebsiteControllerBase
    {
        private readonly IPurchaseOrderAppService purchaseOrderAppService;

        public PurchaseOrderController(IPurchaseOrderAppService purchaseOrderAppService)
        {
            this.purchaseOrderAppService = purchaseOrderAppService;
        }

        [HttpGet]
        public PagedResultDto<PurchaseOrderDto> GetPurchaseOrdersByFilter(PurchaseOrderFilter PurchaseOrderFilter)
        {
            return purchaseOrderAppService.GetPurchaseOrders(PurchaseOrderFilter);
        }

        [HttpGet]
        public PurchaseOrderInput GetPurchaseOrderForEdit(int id)
        {
            return purchaseOrderAppService.GetPurchaseOrderForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditPurchaseOrder([FromBody] PurchaseOrderInput input)
        {
            purchaseOrderAppService.CreateOrEditPurchaseOrder(input);
        }

        [HttpDelete("{id}")]
        public void DeletePurchaseOrder(int id)
        {
            purchaseOrderAppService.DeletePurchaseOrder(id);
        }

        [HttpGet]
        public PurchaseOrderForViewDto GetPurchaseOrderForView(int id)
        {
            return purchaseOrderAppService.GetPurchaseOrderForView(id);
        }
    }
}
