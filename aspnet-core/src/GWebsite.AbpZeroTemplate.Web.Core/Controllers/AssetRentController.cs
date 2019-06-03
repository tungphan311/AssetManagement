using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRents;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRents.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetsRents.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetRentController : GWebsiteControllerBase
    {
        private readonly IAssetRentAppService assetRentAppService;

        public AssetRentController(IAssetRentAppService assetRentAppService)
        {
            this.assetRentAppService = assetRentAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetRentDto> GetAssetRentByFilter(AssetRentFilter assetRentFilter)
        {
            return assetRentAppService.GetAssetRent(assetRentFilter);
        }

        [HttpGet]
        public AssetRentInput GetAssetRentForEdit(int id)
        {
            return assetRentAppService.GetAssetRentForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAssetRent([FromBody] AssetRentInput input)
        {
            assetRentAppService.CreateOrEditAssetRent(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAssetRent(int id)
        {
            assetRentAppService.DeleteAssetRent(id);
        }

        [HttpGet]
        public AssetRentForView GetAssetRenttForView(int id)
        {
            return assetRentAppService.GetAssetRentForView(id);
        }
    }
}

