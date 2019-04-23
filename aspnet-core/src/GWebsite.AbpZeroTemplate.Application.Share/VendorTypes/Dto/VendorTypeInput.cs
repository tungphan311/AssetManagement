using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.VendorTypes.Dto
{
    /// <summary>
    /// <model cref="VendorType"></model>
    /// </summary>
    public class VendorTypeInput : Entity<int>
    {
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
