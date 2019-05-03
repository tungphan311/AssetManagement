using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandise;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandises.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MerchandiseController: GWebsiteControllerBase
    {
        private readonly IMerchandiseAppService merchandiseAppService;

        public MerchandiseController(IMerchandiseAppService appService)
        {
            merchandiseAppService = appService;
        }

        [HttpGet]
        public PagedResultDto<MerchandiseDto> GetMerchandiseByFilter(MerchandiseFilter filter)
        {
            return merchandiseAppService.GetMerchandises(filter);
        }

        [HttpGet]
        public MerchandiseInput GetMerchandiseForEdit(int id)
        {
            return merchandiseAppService.GetMerchandiseForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditMerchandise([FromBody] MerchandiseInput input)
        {
            merchandiseAppService.CreateOrEditMerchandise(input);
        }

        [HttpDelete]
        public void DeleteMerchandise(int id)
        {
            merchandiseAppService.DeleteMerchandise(id);
        }

        [HttpGet]
        public MerchandiseForViewDto GetMerchandiseForView(int id)
        {
            return merchandiseAppService.GetMerchandiseForView(id);
        }
    }
}
