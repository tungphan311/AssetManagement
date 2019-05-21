using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BidController: GWebsiteControllerBase
    {
        private readonly IBidAppService bidAppService;

        public BidController(IBidAppService appService)
        {
            bidAppService = appService;
        }

        [HttpGet]
        public PagedResultDto<BidDto> GetBidByFilter(BidFilter filter)
        {
            return bidAppService.GetBids(filter);
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

        [HttpDelete]
        public void DeleteBid(int id)
        {
            bidAppService.DeleteBid(id);
        }

        [HttpGet]
        public BidForViewDto GetBidForViewDto(int id)
        {
            return bidAppService.GetBidForViewDto(id);
        }
    }
}
