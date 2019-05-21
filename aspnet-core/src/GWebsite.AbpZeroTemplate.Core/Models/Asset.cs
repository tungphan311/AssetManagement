using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset : FullAuditModel
    {
        public string nameAsset { get; set; }
        public int mountAsset { get; set; }
        public bool isRentOut { get; set; }
        public decimal valueAsset { get; set; }
    }
}
