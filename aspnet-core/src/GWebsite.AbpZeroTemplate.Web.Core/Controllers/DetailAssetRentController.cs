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

        public DetailAssetRentController(IDetailAssetRentAppService detailAssetRentAppService)
        {
            this.detailAssetRentAppService = detailAssetRentAppService;
        }

        [HttpGet]
        public PagedResultDto<DetailAssetRentDto> GetDetailAssetRentByFilter(DetailAssetRentFilter detailAssetRentFilter)
        {
            return detailAssetRentAppService.GetDetailAssetRent(detailAssetRentFilter);
        }

        [HttpGet]
        public DetailAssetRentInput GetDetailAssetRentForEdit(int id)
        {
            return detailAssetRentAppService.GetDetailAssetRentForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDetailAssetRent([FromBody] DetailAssetRentInput input)
        {
            detailAssetRentAppService.CreateOrEditDetailAssetRent(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDetailAssetRent(int id)
        {
            detailAssetRentAppService.DeleteDetailAssetRent(id);
        }

        [HttpGet]
        public DetailAssetRentForView GetDetailAssetRenttForView(int id)
        {
            return detailAssetRentAppService.GetDetailAssetRentForView(id);
        }
    }
}

