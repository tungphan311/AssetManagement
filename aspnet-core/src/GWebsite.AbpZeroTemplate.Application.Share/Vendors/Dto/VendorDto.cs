using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vendors.Dto
{
    /// <summary>
    /// <model cref="Vendor"></model>
    /// </summary>
    public class VendorDto : Entity<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int TypeID { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string TIN { get; set; }

        public string PhoneNumber { get; set; }

        public string Contact { get; set; }

        public bool IsActive { get; set; }

        public string Note { get; set; }
    }
}
