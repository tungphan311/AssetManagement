using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors.Dto
{
    /// <summary>
    /// <model cref="Merch_Vendor"></model>
    /// </summary>
    public class Merch_VendorInput : Entity<int>
    {
        public int MerchID { get; set; }
        public int VendorID { get; set; }
    }
}
