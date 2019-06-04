using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS
{
    public interface ITSThueAppService
    {
        void CreateOrEditTSThue(TSThueInput tstInput);
        TSThueInput GetTSThueForEdit(int id);
        void DeleteTSThue(int id);
        PagedResultDto<TaiSanThueDto> GetTSThue(TSThueFilter input);
        TSThueForViewDto GetTSThueForView(int id);
    }
}