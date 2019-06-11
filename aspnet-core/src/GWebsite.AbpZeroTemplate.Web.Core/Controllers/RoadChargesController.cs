using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RoadCharges;
using GWebsite.AbpZeroTemplate.Application.Share.RoadCharges.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RoadChargesController : GWebsiteControllerBase
    {
        private readonly IRoadChargesAppService roadChargesAppService;

        public RoadChargesController(IRoadChargesAppService roadChargesAppService)
        {
            this.roadChargesAppService = roadChargesAppService;
        }

        [HttpGet]
        public PagedResultDto<RoadChargesDto> GetRoadChargessByFilter(RoadChargesFilter roadChargesFilter)
        {
            return roadChargesAppService.GetRoadChargess(roadChargesFilter);
        }

        [HttpGet]
        public RoadChargesInput GetRoadChargesForEdit(int id)
        {
            return roadChargesAppService.GetRoadChargesForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditRoadCharges([FromBody] RoadChargesInput input)
        {
            roadChargesAppService.CreateOrEditRoadCharges(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRoadCharges(int id)
        {
            roadChargesAppService.DeleteRoadCharges(id);
        }

        [HttpGet]
        public RoadChargesForViewDto GetRoadChargesForView(int id)
        {
            return roadChargesAppService.GetRoadChargesForView(id);
        }
    }
}