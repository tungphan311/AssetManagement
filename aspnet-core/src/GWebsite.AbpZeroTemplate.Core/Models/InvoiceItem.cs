using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class InvoiceItem : FullAuditModel
    {
        public int InvoiceID { get; set; }
        public int AssetID { get; set; }
        public int Quantity { get; set; }
    }
}
