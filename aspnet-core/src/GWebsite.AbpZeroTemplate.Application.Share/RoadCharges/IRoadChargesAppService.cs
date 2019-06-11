using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RoadCharges.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.RoadCharges
{
    public interface IRoadChargesAppService
    {
        void CreateOrEditRoadCharges(RoadChargesInput roadChargesInput);
        RoadChargesInput GetRoadChargesForEdit(int id);
        void DeleteRoadCharges(int id);
        PagedResultDto<RoadChargesDto> GetRoadChargess(RoadChargesFilter input);
        RoadChargesForViewDto GetRoadChargesForView(int id);
    }
}