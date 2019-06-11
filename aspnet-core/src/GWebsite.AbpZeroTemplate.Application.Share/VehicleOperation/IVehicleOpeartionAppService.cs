using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations
{
    public interface IVehicleOperationAppService
    {
        void CreateOrEditVehicleOperation(VehicleOperationInput vehicleOperationInput);
        VehicleOperationInput GetVehicleOperationForEdit(int id);
        void DeleteVehicleOperation(int id);
        PagedResultDto<VehicleOperationDto> GetVehicleOperations(VehicleOperationFilter input);
        VehicleOperationForViewDto GetVehicleOperationForView(int id);
        float GetLatestVehicleIndex(float currentKm, int id, string plateNumber);
    }
}