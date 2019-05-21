using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.POs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.POs
{
    public interface IPOAppService: IApplicationService
    {
        void CreateOrEditPO(POInput input);
        POInput GetPOForEdit(int id);
        void DeletePO(int id);
        PagedResultDto<PODto> GetPOs(POFilter input);
        POForViewDto GetPOForView(int id);
    }
}
