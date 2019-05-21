using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class DetailAssetRent : FullAuditModel
    {
        public string nameAsset { get; set; }
        public string rentBy { get; set; }
        public int assetRentId { get; set; }
        public float rate { get; set; }
        public DateTime? dayPay { get; set; }
        public decimal money { get; set; }
        public string describe { get; set; }
        public bool isPay { get; set; }
    }
}


