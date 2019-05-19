using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BidController : GWebsiteControllerBase
    {
        private readonly IBidAppService bidAppService;

        public BidController(IBidAppService bidAppService)
        {
            this.bidAppService = bidAppService;
        }

        [HttpGet]
        public PagedResultDto<BidDto> GetBidsByFilter(BidFilter BidFilter)
        {
            return bidAppService.GetBids(BidFilter);
        }

        [HttpGet]
        public BidInput GetBidForEdit(int id)
        {
            return bidAppService.GetBidForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBid([FromBody] BidInput input)
        {
            bidAppService.CreateOrEditBid(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBid(int id)
        {
            bidAppService.DeleteBid(id);
        }

        [HttpGet]
        public BidForViewDto GetBidForView(int id)
        {
            return bidAppService.GetBidForView(id);
        }
    }
}
