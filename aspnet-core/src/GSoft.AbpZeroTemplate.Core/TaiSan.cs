using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GSoft.AbpZeroTemplate
{
    [Table("PbTaiSan")]
    public class TaiSan : Entity
    {
        [Required]
        [MaxLength(255)]
        public virtual string TenTaiSan { get; set; }

        [MaxLength(255)]
        public virtual string NhomTaiSan { get; set; }

        public virtual int DangTrongKho { get; set; }

        public virtual int DangSuDung { get; set; }

        public virtual int BiHuHong { get; set; }

    }
}