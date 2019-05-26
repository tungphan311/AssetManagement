using Abp.Application.Services.Dto;

namespace GSoft.AbpZeroTemplate.DonVi_s
{
    public class UnitTaiSanDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int SoLuong { get { return SuDung + HuHong + TrongKho; } }

        public int TrongKho { get; set; }

        public int SuDung { get; set; }

        public int HuHong { get; set; }
    }
}