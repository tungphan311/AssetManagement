using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids
{
    public interface IBidAppService
    {
        void CreateOrEditBid(BidInput BidInput);
        BidInput GetBidForEdit(int id);
        void DeleteBid(int id);
        PagedResultDto<BidDto> GetBids(BidFilter input);
        BidForViewDto GetBidForView(int id);
    }
}
