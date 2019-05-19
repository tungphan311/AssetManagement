using Abp.Application.Services.Dto;

namespace GSoft.AbpZeroTemplate.DonVi_s
{
    public class TaiSanDto
    {
        public int Id { get; set; }

        public string TenTaiSan { get; set; }

        public string NhomTaiSan { get; set; }

        public bool IsDeleted { get; set; }
    }
}