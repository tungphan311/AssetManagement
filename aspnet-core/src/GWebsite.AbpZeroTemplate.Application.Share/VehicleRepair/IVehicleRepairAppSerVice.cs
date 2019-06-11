using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs
{
    public interface IVehicleRepairAppService
    {
        void CreateOrEditVehicleRepair(VehicleRepairInput vehicleInput);
        VehicleRepairInput GetVehicleRepairForEdit(int id);
        VehicleRepairInput GetVehicleRepairByAssetForEdit(string assetId);
        void DeleteVehicleRepair(int id);
        PagedResultDto<VehicleRepairDto> GetVehicleRepairs(VehicleRepairFilter input);
        VehicleRepairForViewDto GetVehicleRepairForView(int id);
    }
}