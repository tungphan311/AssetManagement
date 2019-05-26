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
        private readonly IBidderAppService bidderAppService;

        public BidderController(IBidderAppService appService)
        {
            bidderAppService = appService;
        }

        [HttpGet]
        public PagedResultDto<BidderDto> GetBiddersByFilter(BidderFilter filter)
        {
            return bidderAppService.GetBidders(filter);
        }

        [HttpGet]
        public BidderInput GetBidderForEdit(int id)
        {
            return bidderAppService.GetBidderForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBidder([FromBody] BidderInput input)
        {
            bidderAppService.CreateOrEditBidder(input);
        }

        [HttpDelete]
        public void DeleteBidder(int id)
        {
            bidderAppService.DeleteBidder(id);
        }

        [HttpGet]
        public BidderForViewDto GetBidderForView(int id)
        {
            return bidderAppService.GetBidderForView(id);
        }
    }
}
