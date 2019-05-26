using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bidders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bidders
{
    public interface IBidderAppService
    {
        void CreateOrEditBidder(BidderInput input);
        BidderInput GetBidderForEdit(int id);
        void DeleteBidder(int id);
        PagedResultDto<BidderDto> GetBidders(BidderFilter filter);
        BidderForViewDto GetBidderForView(int id);
    }
}
