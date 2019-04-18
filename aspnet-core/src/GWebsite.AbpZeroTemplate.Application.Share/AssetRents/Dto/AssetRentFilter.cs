using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetsRents.Dto
{
    /// <summary>
    /// <model cref="AsssetRent"></model>
    /// </summary>
    public class AssetRentFilter : PagedAndSortedInputDto
    {
        public string nameAsset { get; set; }
        public string rentBy { get; set; }
    }
}

