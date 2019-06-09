using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders.Dto
{
    public class PurchaseOrderFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
