using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents.Dto
{
    /// <summary>
    /// <model cref="DetailAssetRent"></model>
    /// </summary>
    public class DetailAssetRentDto : Entity<int>
    {
        public string nameAsset { get; set; }
        public string rentBy { get; set; }
        public bool isPay { get; set; }
        public string dayPay { get; set; }
        public float rate { get; set; }
        public string describe { get; set; }
        public decimal money { get; set; }
    }
}
