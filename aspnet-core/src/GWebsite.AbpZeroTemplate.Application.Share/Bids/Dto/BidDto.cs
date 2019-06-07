using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Application.Share.Bidders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto
{
    public class BidDto: Entity<int>
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int ProjectId { get; set; }

        public DateTime BeginDay { get; set; }

        public DateTime StartReceivingRecords { get; set; }

        public DateTime EndReceivingRecords { get; set; }

        public string BiddingForm { get; set; }

        public double TotalPrice { get; set; }

        public int BidderID { get; set; }
    }
}
