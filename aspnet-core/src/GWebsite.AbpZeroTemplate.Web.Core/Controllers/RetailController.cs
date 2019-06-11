using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Retails;
using GWebsite.AbpZeroTemplate.Application.Share.Retails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RetailController : GWebsiteControllerBase
    {
        private readonly IRetailAppService retailAppService;

        public RetailController(IRetailAppService retailAppService)
        {
            this.retailAppService = retailAppService;
        }

        [HttpGet]
        public PagedResultDto<RetailDto> GetRetailsByFilter(RetailFilter retailFilter)
        {
            return retailAppService.GetRetails(retailFilter);
        }

        [HttpGet]
        public RetailInput GetRetailForEdit(int id)
        {
            return retailAppService.GetRetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditRetail([FromBody] RetailInput input)
        {
            retailAppService.CreateOrEditRetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRetail(int id)
        {
            retailAppService.DeleteRetail(id);
        }

        [HttpGet]
        public RetailForViewDto GetRetailForView(int id)
        {
            return retailAppService.GetRetailForView(id);
        }
    }
}
