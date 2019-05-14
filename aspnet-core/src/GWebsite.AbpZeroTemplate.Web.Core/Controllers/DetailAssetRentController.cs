using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents;
using GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DetailAssetRentController : GWebsiteControllerBase
    {
        private readonly IDetailAssetRentAppService detailAssetRentAppService;

        public DetailAssetRentController (IDetailAssetRentAppService detailAssetRentAppService)
        {
            this.detailAssetRentAppService = detailAssetRentAppService;
        }

        [HttpGet]
        public PagedResultDto<DetailAssetRentDto> GetDetailAssetRentByFilter(DetailAssetRentFilter detailAssetRentFilter)
        {
            return detailAssetRentAppService.GetDetailAssetRent(detailAssetRentFilter);
        }

        [HttpGet]
        public DetailAssetRentInput GetDetailAssetRentForEdit(int detailId)
        {
            return detailAssetRentAppService.GetDetailAssetRentForEdit(detailId);
        }

        [HttpPost]
        public void CreateOrEditDetailAssetRent([FromBody] DetailAssetRentInput input)
        {
            detailAssetRentAppService.CreateOrEditDetailAssetRent(input);
        }

        [HttpDelete("{detailId}")]
        public void DeleteDetailAssetRent(int detailId)
        {
            detailAssetRentAppService.DeleteDetailAssetRent(detailId);
        }

        [HttpGet]
        public DetailAssetRentForView GetDetailAssetRentForView(int detailId)
        {
            return detailAssetRentAppService.GetDetailAssetRentForView(detailId);
        }
    }
}
