using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using Abp.Application.Services.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets
{
    public interface IAssetAppService
    {
        void CreateOrEditAsset (AssetInput assetInput);
        AssetInput getAssetForEdit(int id);
        void DeleteAsset(int id);
        PagedResultDto<AssetDto> GetAsset(AssetFilter input);
        AssetForView GetAssetForView (int id);
    }
}
