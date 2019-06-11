using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VehicleRegistryController : GWebsiteControllerBase
    {
        private readonly IVehicleRegistryAppService vehicleRegistryAppService;

        public VehicleRegistryController(IVehicleRegistryAppService vehicleRegistryAppService)
        {
            this.vehicleRegistryAppService = vehicleRegistryAppService;
        }

        [HttpGet]
        public PagedResultDto<VehicleRegistryDto> GetVehicleRegistriesByFilter(VehicleRegistryFilter vehicleRegistryFilter)
        {
            return vehicleRegistryAppService.GetVehicleRegistries(vehicleRegistryFilter);
        }

        [HttpGet]
        public VehicleRegistryInput GetVehicleRegistryForEdit(int id)
        {
            return vehicleRegistryAppService.GetVehicleRegistryForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVehicleRegistry([FromBody] VehicleRegistryInput input)
        {
            vehicleRegistryAppService.CreateOrEditVehicleRegistry(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVehicleRegistry(int id)
        {
            vehicleRegistryAppService.DeleteVehicleRegistry(id);
        }

        [HttpGet]
        public VehicleRegistryForViewDto GetVehicleRegistryForView(int id)
        {
            return vehicleRegistryAppService.GetVehicleRegistryForView(id);
        }
        [HttpGet]
        public int GetVehicleRegistryNumber(int insurrancenumber, string plateNumber)
        {
            return vehicleRegistryAppService.GetVehicleRegistryNumber(insurrancenumber, plateNumber);
        }
    }
}