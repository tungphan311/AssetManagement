using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using GSoft.AbpZeroTemplate;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    [Table("Vendor")]
    public class Vendor: FullAuditModel
    {  
        [Required]
        [MaxLength(VendorConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        public virtual int TypeID { get; set; }

        [Required]
        [MaxLength(VendorConsts.MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        [Required]
        [MaxLength(VendorConsts.MaxAddressLength)]
        public virtual string Address { get; set; }

        [Required]
        [MaxLength(VendorConsts.MaxPhoneNumberLength)]
        public virtual string PhoneNumber { get; set; }
    }
}
