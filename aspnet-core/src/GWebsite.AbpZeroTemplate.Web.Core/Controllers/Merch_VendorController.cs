using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors;
using GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class Merch_VendorController : GWebsiteControllerBase
    {
        private readonly IMerch_VendorAppService merchvendorAppService;

        public Merch_VendorController(IMerch_VendorAppService merchvendorAppService)
        {
            this.merchvendorAppService = merchvendorAppService;
        }

        [HttpGet]
        public PagedResultDto<Merch_VendorDto> GetMerch_VendorsByFilter(Merch_VendorFilter merchvendorFilter)
        {
            return merchvendorAppService.GetMerch_Vendors(merchvendorFilter);
        }

        [HttpGet]
        public Merch_VendorInput GetMerch_VendorForEdit(int id)
        {
            return merchvendorAppService.GetMerch_VendorForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditMerch_Vendor([FromBody] Merch_VendorInput input)
        {
            merchvendorAppService.CreateOrEditMerch_Vendor(input);
        }

        [HttpDelete("{id}")]
        public void DeleteMerch_Vendor(int id)
        {
            merchvendorAppService.DeleteMerch_Vendor(id);
        }
    }
}
