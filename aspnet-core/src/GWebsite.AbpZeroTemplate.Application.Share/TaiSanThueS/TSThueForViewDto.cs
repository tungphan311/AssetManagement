using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS.Dto
{

    /// <summary>
    /// <model cref="TaiSanThue"></model>
    /// </summary>
    public class TSThueForViewDto
    {
        public string MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public string TrangThai { get; set; }
        public string GiaTien { get; set; }
        public string NgayTra { get; set; }
    }
}
