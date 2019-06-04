using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS.Dto
{
    /// <summary>
    /// <model cref="TaiSanThue"></model>
    /// </summary>
    public class TSThueInput : Entity<int>
    {
        public string MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public string TrangThai { get; set; }
        public string GiaTien { get; set; }
        public string NgayTra { get; set; }
    }
}