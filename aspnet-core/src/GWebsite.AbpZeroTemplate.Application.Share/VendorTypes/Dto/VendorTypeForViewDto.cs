using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.VendorTypes.Dto
{
    /// <summary>
    /// <model cref="VendorType"></model>
    /// </summary>
    public class VendorTypeForViewDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
