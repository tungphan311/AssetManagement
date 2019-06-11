using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries
{
    public interface IVehicleRegistryAppService
    {
        void CreateOrEditVehicleRegistry(VehicleRegistryInput vehicleRegistryInput);
        VehicleRegistryInput GetVehicleRegistryForEdit(int id);
        void DeleteVehicleRegistry(int id);
        PagedResultDto<VehicleRegistryDto> GetVehicleRegistries(VehicleRegistryFilter input);
        VehicleRegistryForViewDto GetVehicleRegistryForView(int id);
        int GetVehicleRegistryNumber(string plateNumber);
    }
}
