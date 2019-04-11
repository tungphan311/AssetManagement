using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace GSoft.AbpZeroTemplate.Purchasing
{
    [Table("Invoices")]
    public class Invoice: FullAuditedEntity
    {
        public const int MaxNameLength = 50;
        public const int MaxStaffNameLength = 50;
        
        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(MaxStaffNameLength)]
        public virtual string StaffName { get; set; }

        [Required]
        public virtual DateTime DateCreated { get; set; }
    }
}
