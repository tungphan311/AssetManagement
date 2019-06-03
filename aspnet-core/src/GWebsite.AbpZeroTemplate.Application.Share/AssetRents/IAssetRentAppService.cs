using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRents.Dto;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetsRents.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRents
{
    public interface IAssetRentAppService
    {
        void CreateOrEditAssetRent(AssetRentInput assetInput);
        AssetRentInput GetAssetRentForEdit(int id);
        void DeleteAssetRent(int id);
        PagedResultDto<AssetRentDto> GetAssetRent(AssetRentFilter input);
        AssetRentForView GetAssetRentForView(int id);
    }
}
