using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents.Dto;
using Abp.Application.Services.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents
{
    public interface IDetailAssetRentAppService
    {
        void CreateOrEditDetailAssetRent(DetailAssetRentInput assetInput);
        DetailAssetRentInput GetDetailAssetRentForEdit(int id);
        void DeleteDetailAssetRent(int id);
        PagedResultDto<DetailAssetRentDto> GetDetailAssetRent(DetailAssetRentFilter input);
        DetailAssetRentForView GetDetailAssetRentForView(int id);
    }
}
