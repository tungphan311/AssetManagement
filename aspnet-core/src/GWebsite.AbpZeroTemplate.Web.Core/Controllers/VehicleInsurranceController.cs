using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances.Dto;
using Microsoft.AspNetCore.Mvc;
//Insurrance
namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VehicleInsurranceController : GWebsiteControllerBase
    {
        private readonly IVehicleInsurranceAppService vehicleInsurranceAppService;

        public VehicleInsurranceController(IVehicleInsurranceAppService vehicleInsurranceAppService)
        {
            this.vehicleInsurranceAppService = vehicleInsurranceAppService;
        }

        [HttpGet]
        public PagedResultDto<VehicleInsurranceDto> GetVehicleInsurrancesByFilter(VehicleInsurranceFilter vehicleInsurranceFilter)
        {
            return vehicleInsurranceAppService.GetVehicleInsurrances(vehicleInsurranceFilter);
        }

        [HttpGet]
        public VehicleInsurranceInput GetVehicleInsurranceForEdit(int id)
        {
            return vehicleInsurranceAppService.GetVehicleInsurranceForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVehicleInsurrance([FromBody] VehicleInsurranceInput input)
        {
            vehicleInsurranceAppService.CreateOrEditVehicleInsurrance(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVehicleInsurrance(int id)
        {
            vehicleInsurranceAppService.DeleteVehicleInsurrance(id);
        }

        [HttpGet]
        public VehicleInsurranceForViewDto GetVehicleInsurranceForView(int id)
        {
            return vehicleInsurranceAppService.GetVehicleInsurranceForView(id);
        }
        [HttpGet]
        public int GetVehicleInsurranceNumber(string plateNumber)
        {
            return vehicleInsurranceAppService.GetVehicleInsurranceNumber(plateNumber);
        }
    }
}