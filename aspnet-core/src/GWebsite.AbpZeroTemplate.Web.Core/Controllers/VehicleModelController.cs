using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleModels;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleModels.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VehicleModelController : GWebsiteControllerBase
    {
        private readonly IVehicleModelAppService vehicleModelAppService;

        public VehicleModelController(IVehicleModelAppService vehicleModelAppService)
        {
            this.vehicleModelAppService = vehicleModelAppService;
        }

        [HttpGet]
        public PagedResultDto<VehicleModelDto> GetVehicleModelsByFilter(VehicleModelFilter vehicleModelFilter)
        {
            return vehicleModelAppService.GetVehicleModels(vehicleModelFilter);
        }

        [HttpGet]
        public PagedResultDto<VehicleModelDto> GetVehicleModels()
        {
            return vehicleModelAppService.GetAllVehicleModels();
        }

        [HttpGet]
        public VehicleModelInput GetVehicleModelForEdit(int id)
        {
            return vehicleModelAppService.GetVehicleModelForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVehicleModel([FromBody] VehicleModelInput input)
        {
            vehicleModelAppService.CreateOrEditVehicleModel(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVehicleModel(int id)
        {
            vehicleModelAppService.DeleteVehicleModel(id);
        }

        [HttpGet]
        public VehicleModelForViewDto GetVehicleModelForView(int id)
        {
            return vehicleModelAppService.GetVehicleModelForView(id);
        }
    }
}