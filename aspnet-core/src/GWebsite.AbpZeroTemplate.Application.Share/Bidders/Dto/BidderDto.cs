using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bidders.Dto
{
    public class BidderDto: Entity<int>
    {
        public int VendorId { get; set; }

        public DateTime ApplyDay { get; set; }

        public double OfferPrice { get; set; }

        public bool isAccept { get; set; }

        public string GuaranteeMethod { get; set; }

        public DateTime GuaranteeExpired { get; set; }

        public int CertificateNumber { get; set; }

        public string Note { get; set; }

        public int BidID { get; set; }
    }
}
