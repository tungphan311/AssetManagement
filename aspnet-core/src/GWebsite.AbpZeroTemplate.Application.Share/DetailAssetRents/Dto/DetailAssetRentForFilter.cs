using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents.Dto
{
    /// <summary>
    /// <model cref="DetailAssetRent"></model>
    /// </summary>
    public class DetailAssetRentFilter : PagedAndSortedInputDto
    {
        public string rentBy { get; set; }
        public string nameAsset { get; set; }

    }
}