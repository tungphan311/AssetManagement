using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids
{
    public interface IBidAppService: IApplicationService
    {
        void CreateOrEditBid(BidInput input);
        BidInput GetBidForEdit(int id);
        void DeleteBid(int id);
        PagedResultDto<BidDto> GetBids(BidFilter filter);
        BidForViewDto GetBidForViewDto(int id);
    }
}
