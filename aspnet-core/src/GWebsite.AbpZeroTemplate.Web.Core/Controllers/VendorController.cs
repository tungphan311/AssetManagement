using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vendors;
using GWebsite.AbpZeroTemplate.Application.Share.Vendors.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VendorController : GWebsiteControllerBase
    {
        private readonly IVendorAppService vendorAppService;

        public VendorController(IVendorAppService vendorAppService)
        {
            this.vendorAppService = vendorAppService;
        }

        [HttpGet]
        public PagedResultDto<VendorDto> GetVendorsByFilter(VendorFilter vendorFilter)
        {
            return vendorAppService.GetVendors(vendorFilter);
        }

        [HttpGet]
        public VendorInput GetVendorForEdit(int id)
        {
            return vendorAppService.GetVendorForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVendor([FromBody] VendorInput input)
        {
            vendorAppService.CreateOrEditVendor(input);
        }

        [HttpDelete("{id}")]
        public void DeleteVendor(int id)
        {
            vendorAppService.DeleteVendor(id);
        }

        [HttpGet]
        public VendorForViewDto GetVendorForView(int id)
        {
            return vendorAppService.GetVendorForView(id);
        }
    }
}
