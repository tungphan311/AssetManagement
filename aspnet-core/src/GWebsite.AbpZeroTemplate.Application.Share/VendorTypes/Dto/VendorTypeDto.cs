using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.VendorTypes.Dto
{
    /// <summary>
    /// <model cref="VendorType"></model>
    /// </summary>
    public class VendorTypeDto : Entity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
