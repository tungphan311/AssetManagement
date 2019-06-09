using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders
{
    public interface IPurchaseOrderAppService
    {
        void CreateOrEditPurchaseOrder(PurchaseOrderInput PurchaseOrderInput);
        PurchaseOrderInput GetPurchaseOrderForEdit(int id);
        void DeletePurchaseOrder(int id);
        PagedResultDto<PurchaseOrderDto> GetPurchaseOrders(PurchaseOrderFilter input);
        PurchaseOrderForViewDto GetPurchaseOrderForView(int id);
    }
}
