using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Bidder: FullAuditModel
    {
        public int VendorId { get; set; }

        public DateTime ApplyDay { get; set; }

        public double OfferPrice { get; set; }

        public string GuaranteeMethod { get; set; } 

        public DateTime GuaranteeExpired { get; set; }

        public int CertificateNumber { get; set; }

        public string Note { get; set; }

        public int BidID { get; set; }
    }
}
