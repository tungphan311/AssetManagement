using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances
{
    public interface IVehicleMaintenanceAppService
    {
        void CreateOrEditVehicleMaintenance(VehicleMaintenanceInput vehicleMaintenanceInput);
        VehicleMaintenanceInput GetVehicleMaintenanceForEdit(int id);
        void DeleteVehicleMaintenance(int id);
        PagedResultDto<VehicleMaintenanceDto> GetVehicleMaintenances(VehicleMaintenanceFilter input);
        VehicleMaintenanceForViewDto GetVehicleMaintenanceForView(int id);
        int GetVehicleMaintenanceNumber(string plateNumber);
    }
}