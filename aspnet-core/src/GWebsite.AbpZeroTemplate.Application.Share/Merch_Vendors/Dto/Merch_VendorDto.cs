using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors.Dto
{
    /// <summary>
    /// <model cref="Merch_Vendor"></model>
    /// </summary>
    public class Merch_VendorDto : Entity<int>
    {
        public int MerchID { get; set; }
        public int VendorID { get; set; }
    }
}
