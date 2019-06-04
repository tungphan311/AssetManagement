using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class TaiSanThue : FullAuditModel
    {
        public string MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public string TrangThai { get; set; }
        public string GiaTien { get; set; }
        public string NgayTra { get; set; }
    }
}
