using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VendorTypes;
using GWebsite.AbpZeroTemplate.Application.Share.VendorTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VendorTypeController : GWebsiteControllerBase
    {
        private readonly IVendorTypeAppService vendortypeAppService;

        public VendorTypeController(IVendorTypeAppService vendortypeAppService)
        {
            this.vendortypeAppService = vendortypeAppService;
        }

        [HttpGet]
        public PagedResultDto<VendorTypeDto> GetVendorTypesByFilter(VendorTypeFilter vendortypeFilter)
        {
            return vendortypeAppService.GetVendorTypes(vendortypeFilter);
        }

        [HttpGet]
        public VendorTypeInput GetVendorTypeForEdit(int id)
        {
            return vendortypeAppService.GetVendorTypeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVendorType([FromBody] VendorTypeInput input)
        {
            vendortypeAppService.CreateOrEditVendorType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVendorType(int id)
        {
            vendortypeAppService.DeleteVendorType(id);
        }

        [HttpGet]
        public VendorTypeForViewDto GetVendorTypeForView(int id)
        {
            return vendortypeAppService.GetVendorTypeForView(id);
        }
    }
}
