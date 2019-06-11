using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleModels.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleModels
{
    public interface IVehicleModelAppService
    {
        void CreateOrEditVehicleModel(VehicleModelInput vehicleModelInput);
        VehicleModelInput GetVehicleModelForEdit(int id);
        void DeleteVehicleModel(int id);
        PagedResultDto<VehicleModelDto> GetVehicleModels(VehicleModelFilter input);
        PagedResultDto<VehicleModelDto> GetAllVehicleModels();
        VehicleModelForViewDto GetVehicleModelForView(int id);
    }
}