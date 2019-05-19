using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BidDetailController : GWebsiteControllerBase
    {
        private readonly IBidDetailAppService bidDetailAppService;

        public BidDetailController(IBidDetailAppService bidDetailAppService)
        {
            this.bidDetailAppService = bidDetailAppService;
        }

        [HttpGet]
        public PagedResultDto<BidDetailDto> GetBidDetailsByFilter(BidDetailFilter BidDetailFilter)
        {
            return bidDetailAppService.GetBidDetails(BidDetailFilter);
        }

        [HttpGet]
        public BidDetailInput GetBidDetailForEdit(int id)
        {
            return bidDetailAppService.GetBidDetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBidDetail([FromBody] BidDetailInput input)
        {
            bidDetailAppService.CreateOrEditBidDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBidDetail(int id)
        {
            bidDetailAppService.DeleteBidDetail(id);
        }
        [HttpDelete("{bidId}")]
        public void DeleteMultiBidDetail(int bidId)
        {
            bidDetailAppService.DeleteMultiBidDetail(bidId);
        }

        [HttpGet]
        public BidDetailForViewDto GetBidDetailForView(int id)
        {
            return bidDetailAppService.GetBidDetailForView(id);
        }
    }
}
