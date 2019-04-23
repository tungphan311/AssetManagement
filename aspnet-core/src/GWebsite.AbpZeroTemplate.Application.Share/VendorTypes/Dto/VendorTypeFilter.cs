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
        public string Name { get; set; }
    }
}
