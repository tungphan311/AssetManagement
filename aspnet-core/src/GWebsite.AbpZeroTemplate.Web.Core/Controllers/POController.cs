using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.POs;
using GWebsite.AbpZeroTemplate.Application.Share.POs.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class POController: GWebsiteControllerBase
    {
        private readonly IPOAppService poAppService;

        public POController(IPOAppService appService)
        {
            poAppService = appService;
        }

        [HttpGet]
        public PagedResultDto<PODto> GetPOByFilter(POFilter filter)
        {
            return poAppService.GetPOs(filter);
        }

        [HttpGet]
        public POInput GetPOForEdit(int id)
        {
            return poAppService.GetPOForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditPO([FromBody] POInput input)
        {
            poAppService.CreateOrEditPO(input);
        }

        [HttpDelete]
        public void DeletePO(int id)
        {
            poAppService.DeletePO(id);
        }

        [HttpGet]
        public POForViewDto GetPOForView(int id)
        {
            return poAppService.GetPOForView(id);
        }
    }
}
