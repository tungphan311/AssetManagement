using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto
{
    public class BidFilter: PagedAndSortedInputDto
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public DateTime StartReceivingRecords { get; set; }

        public DateTime EndReceivingRecords { get; set; }

        public string BiddingForm { get; set; }

        public int VendorId { get; set; }
    }
}
