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
    [Table("Merchandise")]
    public class Merchandise: FullAuditModel
    {  
        [Required]
        [MaxLength(MerchandiseConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        public virtual int TypeID { get; set; }

        [Required]
        [MaxLength(MerchandiseConsts.MaxInfoLength)]
        public virtual string Info { get; set; }

        [Required]
        public virtual double Price { get; set; }
    }
}
