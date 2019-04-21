using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandise;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandise.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MerchandiseControlller: GWebsiteControllerBase
    {
        private readonly IMerchandiseAppService _merchandiseAppService;

        public MerchandiseControlller(IMerchandiseAppService merchandiseAppService)
        {
            _merchandiseAppService = merchandiseAppService;
        }

        [HttpGet]
        public ListResultDto<MerchandiseListDto> GetMerchandise(GetMerchandiseInput input)
        {
            return _merchandiseAppService.GetMerchandise(input);
        }

        [HttpPost]
        public async Task<MerchandiseDto> CreateMerchandise([FromBody]CreateMerchandiseInput input)
        {
            return await _merchandiseAppService.CreateMerchandise(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMerchandise(int id)
        {
            await _merchandiseAppService.DeleteMerchandise(new EntityDto<int>() { Id = id });
        }
    }
}
