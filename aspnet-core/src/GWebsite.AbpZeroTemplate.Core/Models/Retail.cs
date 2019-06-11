using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Retail:FullAuditModel
    {
        public string Code { get; set; }
        public int MerchandiseID { get; set; }
        public int VendorID { get; set; }
        public int Quantity { get; set; }
        public int BoughtQuantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
