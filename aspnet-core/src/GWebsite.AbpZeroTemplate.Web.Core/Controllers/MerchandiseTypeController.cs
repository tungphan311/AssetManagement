using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes;
using GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MerchandiseTypeController: GWebsiteControllerBase
    {
        private readonly IMerchandiseTypeAppService merchandiseTypeAppService;

        public MerchandiseTypeController(IMerchandiseTypeAppService appService)
        {
            merchandiseTypeAppService = appService;
        }

        [HttpGet]
        public PagedResultDto<MerchandiseTypeDto> GetMerchandiseByFilter(MerchandiseTypeFilter filter)
        {
            return merchandiseTypeAppService.GetMerchandiseTypes(filter);
        }

        [HttpGet]
        public MerchandiseTypeInput GetMerchandiseTypeForEdit(int id)
        {
            return merchandiseTypeAppService.GetMerchandiseTypeForEdit(id);
        }

        [HttpGet]
        public String GetNameById(int id)
        {
            return merchandiseTypeAppService.GetNameById(id);
        }

        [HttpPost]
        public void CreateOrEditMerchandiseType([FromBody] MerchandiseTypeInput input)
        {
            merchandiseTypeAppService.CreateOrEditMerchandiseType(input);
        }

        [HttpDelete]
        public void DeleteMerchandiseType(int id)
        {
            merchandiseTypeAppService.DeleteMerchandiseType(id);
        }

        [HttpGet]
        public MerchandiseTypeForViewDto GetMerchandiseTypeForView(int id)
        {
            return merchandiseTypeAppService.GetMerchandiseTypeForView(id);
        }
    }
}
