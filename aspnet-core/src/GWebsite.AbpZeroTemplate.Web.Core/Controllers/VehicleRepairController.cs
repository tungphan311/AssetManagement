using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VehicleRepairController : GWebsiteControllerBase
    {
        private readonly IVehicleRepairAppService vehicleRepairAppService;

        public VehicleRepairController(IVehicleRepairAppService vehicleRepairAppService)
        {
            this.vehicleRepairAppService = vehicleRepairAppService;
        }

        [HttpGet]
        public PagedResultDto<VehicleRepairDto> GetVehicleRepairsByFilter(VehicleRepairFilter vehicleRepairFilter)
        {
            return vehicleRepairAppService.GetVehicleRepairs(vehicleRepairFilter);
        }

        [HttpGet]
        public VehicleRepairInput GetVehicleRepairForEdit(int id)
        {
            return vehicleRepairAppService.GetVehicleRepairForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVehicleRepair([FromBody] VehicleRepairInput input)
        {
            vehicleRepairAppService.CreateOrEditVehicleRepair(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVehicleRepair(int id)
        {
            vehicleRepairAppService.DeleteVehicleRepair(id);
        }

        [HttpGet]
        public VehicleRepairForViewDto GetVehicleRepairForView(int id)
        {
            return vehicleRepairAppService.GetVehicleRepairForView(id);
        }
        [HttpGet]
        public VehicleRepairInput GetVehicleRepairByAssetForEdit(string assetId)
        {
            return vehicleRepairAppService.GetVehicleRepairByAssetForEdit(assetId);
        }
    }
}