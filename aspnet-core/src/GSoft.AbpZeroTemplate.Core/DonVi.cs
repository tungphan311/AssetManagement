using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GSoft.AbpZeroTemplate
{
    [Table("PbDonVi")]
    public class DonVi : Entity
    {
        [Required]
        [MaxLength(255)]
        public virtual string TenDonVi { get; set; }

        public virtual int DonViChinhId { get; set; }

        public virtual string DiaChi { get; set; }
    }
}
