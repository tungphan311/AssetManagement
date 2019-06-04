using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TSThueController : GWebsiteControllerBase
    {
        private readonly ITSThueAppService customerAppService;

        public TSThueController(ITSThueAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<TaiSanThueDto> GetTSThuesByFilter(TSThueFilter customerFilter)
        {
            return customerAppService.GetTSThue(customerFilter);
        }

        [HttpGet]
        public TSThueInput GetTSThueForEdit(int id)
        {
            return customerAppService.GetTSThueForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTSThue([FromBody] TSThueInput input)
        {
            customerAppService.CreateOrEditTSThue(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTSThue(int id)
        {
            customerAppService.DeleteTSThue(id);
        }

        [HttpGet]
        public TSThueForViewDto GetTSThueForView(int id)
        {
            return customerAppService.GetTSThueForView(id);
        }
    }
}