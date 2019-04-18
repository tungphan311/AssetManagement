using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Domain.Entities;
namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRents.Dto
{
    /// <summary>
    /// <model cref="AssetRent"></model>
    /// </summary>
    public class AssetRentDto : Entity<int>
    {
        public string nameAsset { get; set; }
        public string rentBy { get; set; }
        public DateTime? dateRent { get; set; }
        public DateTime? datePay { get; set; }
        public int numberRent { get; set; }
        public int numberPay { get; set; }

    }
}
