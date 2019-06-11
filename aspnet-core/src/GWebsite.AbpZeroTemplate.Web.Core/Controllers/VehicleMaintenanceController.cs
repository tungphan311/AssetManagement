using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VehicleMaintenanceController : GWebsiteControllerBase
    {
        private readonly IVehicleMaintenanceAppService vehicleMaintenanceAppService;

        public VehicleMaintenanceController(IVehicleMaintenanceAppService vehicleMaintenanceAppService)
        {
            this.vehicleMaintenanceAppService = vehicleMaintenanceAppService;
        }

        [HttpGet]
        public PagedResultDto<VehicleMaintenanceDto> GetVehicleMaintenancesByFilter(VehicleMaintenanceFilter vehicleMaintenanceFilter)
        {
            return vehicleMaintenanceAppService.GetVehicleMaintenances(vehicleMaintenanceFilter);
        }

        [HttpGet]
        public VehicleMaintenanceInput GetVehicleMaintenanceForEdit(int id)
        {
            return vehicleMaintenanceAppService.GetVehicleMaintenanceForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVehicleMaintenance([FromBody] VehicleMaintenanceInput input)
        {
            vehicleMaintenanceAppService.CreateOrEditVehicleMaintenance(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVehicleMaintenance(int id)
        {
            vehicleMaintenanceAppService.DeleteVehicleMaintenance(id);
        }

        [HttpGet]
        public VehicleMaintenanceForViewDto GetVehicleMaintenanceForView(int id)
        {
            return vehicleMaintenanceAppService.GetVehicleMaintenanceForView(id);
        }

        [HttpGet]
        public int GetVehicleMaintenanceNumber(string plateNumber)
        {
            return vehicleMaintenanceAppService.GetVehicleMaintenanceNumber(plateNumber);
        }
    }
}