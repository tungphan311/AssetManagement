using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bidders;
using GWebsite.AbpZeroTemplate.Application.Share.Bidders.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BidderController: GWebsiteControllerBase
    {
        private readonly IBidderAppService bidAppService;

        public BidderController(IBidderAppService appService)
        {
            bidAppService = appService;
        }

        [HttpGet]
        public PagedResultDto<BidderDto> GetBidderByFilter(BidderFilter filter)
        {
            return bidAppService.GetBidders(filter);
        }

        [HttpGet]
        public BidderInput GetBidderForEdit(int id)
        {
            return bidAppService.GetBidderForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBid([FromBody] BidderInput input)
        {
            bidAppService.CreateOrEditBidder(input);
        }

        [HttpDelete]
        public void DeleteBidder(int id)
        {
            bidAppService.DeleteBidder(id);
        }
    }
}
