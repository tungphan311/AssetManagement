using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace GSoft.AbpZeroTemplate
{
    [Table("PbDonVi")]
    public class DonVi : FullAuditedEntity
    {
        [Required]
        [MaxLength(255)]
        public virtual string TenDonVi { get; set; }

        [Required]
        public virtual int TaiSanSuDung { get; set; }

        [Required]
        public virtual int TaiSanHu { get; set; }

        [Required]
        public virtual int TaiSanTrongKho { get; set; }

        [MaxLength(255)]
        public virtual string DonViChinh { get; set; }
    }
}
