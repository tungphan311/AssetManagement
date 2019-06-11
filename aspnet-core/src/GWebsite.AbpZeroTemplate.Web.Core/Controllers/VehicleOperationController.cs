using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VehicleOperationController : GWebsiteControllerBase
    {
        private readonly IVehicleOperationAppService vehicleOperationAppService;

        public VehicleOperationController(IVehicleOperationAppService vehicleOperationAppService)
        {
            this.vehicleOperationAppService = vehicleOperationAppService;
        }

        [HttpGet]
        public PagedResultDto<VehicleOperationDto> GetVehicleOperationsByFilter(VehicleOperationFilter vehicleOperationFilter)
        {
            return vehicleOperationAppService.GetVehicleOperations(vehicleOperationFilter);
        }

        [HttpGet]
        public VehicleOperationInput GetVehicleOperationForEdit(int id)
        {
            return vehicleOperationAppService.GetVehicleOperationForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVehicleOperation([FromBody] VehicleOperationInput input)
        {
            vehicleOperationAppService.CreateOrEditVehicleOperation(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVehicleOperation(int id)
        {
            vehicleOperationAppService.DeleteVehicleOperation(id);
        }

        [HttpGet]
        public VehicleOperationForViewDto GetVehicleOperationForView(int id)
        {
            return vehicleOperationAppService.GetVehicleOperationForView(id);
        }

        [HttpGet]
        public float GetLatestVehicleIndex(float currentKm, int id, string plateNumber)
        {
            return vehicleOperationAppService.GetLatestVehicleIndex(currentKm, id, plateNumber);
        }
    }
}