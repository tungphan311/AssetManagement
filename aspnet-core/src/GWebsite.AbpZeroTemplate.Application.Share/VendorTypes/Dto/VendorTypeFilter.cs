using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.VendorTypes.Dto
{
    /// <summary>
    /// <model cref="VendorType"></model>
    /// </summary>
    public class VendorTypeFilter : PagedAndSortedInputDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
    }
}
