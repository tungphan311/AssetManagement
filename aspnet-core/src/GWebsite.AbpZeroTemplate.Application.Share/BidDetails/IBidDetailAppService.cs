using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.BidDetails
{
    public interface IBidDetailAppService
    {
        void CreateOrEditBidDetail(BidDetailInput bidDetailInput);
        BidDetailInput GetBidDetailForEdit(int id);
        void DeleteBidDetail(int id);
        void DeleteMultiBidDetail(int bidId);
        PagedResultDto<BidDetailDto> GetBidDetails(BidDetailFilter input);
        BidDetailForViewDto GetBidDetailForView(int id);
    }
}
