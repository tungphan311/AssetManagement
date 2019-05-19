using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto
{
    public class BidForViewDto
    {
        public string Code { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public BidStatus BidStatus { get; set; }
        public BiddingForm BiddingForm { get; set; }
        public string ProjectCode { get; set; }
        public decimal CautionMoney { get; set; }
        public string AttachmentFile { get; set; }
        public int? ProjectId { get; set; }
    }
}
