using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vendors.Dto
{
    /// <summary>
    /// <model cref="Vendor"></model>
    /// </summary>
    public class VendorFilter : PagedAndSortedInputDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int TypeID { get; set; }

        public string IsActive { get; set; }
    }
}
