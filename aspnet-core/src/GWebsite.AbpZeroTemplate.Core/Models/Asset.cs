using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset : FullAuditModel
    {
        //public int assetID { get; set; }
        public string nameAsset { get; set; }
        public int mountAsset { get; set; }
        public int valueAsset { get; set; }
        public bool isRentOut { get; set; }
        //public string picture { get; set; }
        //public string describe { get; set;  }
        public decimal valueAsset { get; set; }

        
    }
}
