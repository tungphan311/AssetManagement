using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bidders.Dto
{
    public class BidderFilter: PagedAndSortedInputDto
    {
        public int BidID { get; set; }
    }
}
