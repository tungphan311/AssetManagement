using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS.Dto
{

    /// <summary>
    /// <model cref="TaiSanThue"></model>
    /// </summary>
    public class TSThueFilter : PagedAndSortedInputDto
    {
        public string MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
    }
}
