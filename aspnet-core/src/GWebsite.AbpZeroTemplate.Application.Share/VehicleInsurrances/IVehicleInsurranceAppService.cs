using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances.Dto;


namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances
{
    public interface IVehicleInsurranceAppService
    {
        void CreateOrEditVehicleInsurrance(VehicleInsurranceInput vehicleInsurranceInput);
        VehicleInsurranceInput GetVehicleInsurranceForEdit(int id);
        void DeleteVehicleInsurrance(int id);
        PagedResultDto<VehicleInsurranceDto> GetVehicleInsurrances(VehicleInsurranceFilter input);
        VehicleInsurranceForViewDto GetVehicleInsurranceForView(int id);
        int GetVehicleInsurranceNumber(string plateNumber);
    }
}
