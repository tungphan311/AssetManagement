using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.POMerchandises;
using GWebsite.AbpZeroTemplate.Application.Share.POMerchandises.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class POMerchandiseController: GWebsiteControllerBase
    {
        private readonly IPOMerchandiseAppService appService;

        public POMerchandiseController(IPOMerchandiseAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public PagedResultDto<POMerchandiseDto> GetPOByFilter(POMerchandiseFilter filter)
        {
            return appService.GetPOMerchandises(filter);
        }
    }
}
