using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;
using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto
{
    public class BidDetailForViewDto
    {
        public bool IsAccepted { get; set; }
        public DateTime? BiddingCreatedDate { get; set; }
        public string AttachmentFile { get; set; }
        public decimal BidPrice { get; set; }
        public GuaranteeForm GuaranteeForm { get; set; }
        public DateTime? GuaranteeEndDate { get; set; }
        public string CertificateNumber { get; set; }
        public string BankName { get; set; }
        public string Note { get; set; }
        public int ProviderId { get; set; }
        public int BidId { get; set; }
        public ProviderDto Provider { get; set; }
        public BidDto Bid { get; set; }
    }
}
