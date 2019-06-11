using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.POMerchandises.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.POMerchandises
{
    public interface IPOMerchandiseAppService: IApplicationService
    {
        void CreateOrEditPOMerchandise(POMerchandiseInput input);
        POMerchandiseInput GetPOMerchandiseForEdit(int id);
        void DeletePOMerchandise(int id);
        PagedResultDto<POMerchandiseDto> GetPOs(POMerchandiseFilter input);
        POMerchandiseForViewDto GetPOMerchandiseForView(int id);
    }
}
