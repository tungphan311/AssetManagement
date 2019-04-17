using Abp.Application.Services.Dto;

namespace GSoft.AbpZeroTemplate.DonVi_s
{
    public class DonViDto : FullAuditedEntityDto
    {
        public string TenDonVi { get; set; }

        public string DonViChinh { get; set; }

        public int TaiSanSuDung { get; set; }

        public int TaiSanHu { get; set; }

        public int TaiSanTrongKho { get; set; }

        public int SoLuongTaiSan { get { return TaiSanSuDung + TaiSanHu + TaiSanTrongKho; } }
    }
}