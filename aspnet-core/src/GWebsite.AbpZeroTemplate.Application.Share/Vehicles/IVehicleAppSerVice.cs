using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vehicles
{
    public interface IVehicleAppService
    {
        void CreateOrEditVehicle(VehicleInput vehicleInput);
        VehicleInput GetVehicleForEdit(int id);
        void DeleteVehicle(int id);
        PagedResultDto<VehicleDto> GetVehicles(VehicleFilter input);
        VehicleForViewDto GetVehicleForView(int id);
    }
}