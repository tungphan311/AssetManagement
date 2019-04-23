using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vendors.Dto
{
    /// <summary>
    /// <model cref="Vendor"></model>
    /// </summary>
    public class VendorForViewDto
    {
        public string Name { get; set; }
        public int TypeID { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
