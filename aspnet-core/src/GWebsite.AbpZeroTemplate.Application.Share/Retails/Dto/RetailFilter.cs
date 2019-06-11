using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Retails.Dto
{
    public class RetailFilter : PagedAndSortedInputDto
    {
        public int MerchandiseID { get; set; }
        public int VendorID { get; set; }
    }
}
