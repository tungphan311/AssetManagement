using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes
{
    public interface IMerchandiseTypeAppService
    {
        void CreateOrEditMerchandiseType(MerchandiseTypeInput input);
        MerchandiseTypeInput GetMerchandiseTypeForEdit(int id);
        void DeleteMerchandiseType(int id);
        String GetNameById(int id);
        PagedResultDto<MerchandiseTypeDto> GetMerchandiseTypes(MerchandiseTypeFilter input);
        MerchandiseTypeForViewDto GetMerchandiseTypeForView(int id);
    }
}
