using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors.Dto
{
    /// <summary>
    /// <model cref="Merch_Vendor"></model>
    /// </summary>
    public class Merch_VendorFilter : PagedAndSortedInputDto
    {
        public int VendorID { get; set; }
    }
}
