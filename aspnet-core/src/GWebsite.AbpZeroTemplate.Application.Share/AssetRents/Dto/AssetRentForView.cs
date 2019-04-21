using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRents.Dto
{
   public class AssetRentForView : Entity
    {
        public string nameAsset { get; set; }
        public string rentBy { get; set; }
        public DateTime? DateRent { get; set; } 
        public DateTime? datePay { get; set; }
        public int numberRent { get; set; }
        public int numberPay { get; set; }
    }

}
