using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset5s;
using GWebsite.AbpZeroTemplate.Application.Share.Asset5s.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class Asset5Controller : GWebsiteControllerBase
    {
        private readonly IAsset5AppService asset5AppService;

        public Asset5Controller(IAsset5AppService asset5AppService)
        {
            this.asset5AppService = asset5AppService;
        }

        [HttpGet]
        public PagedResultDto<Asset5Dto> GetAsset5sByFilter(Asset5Filter asset5Filter)
        {
            return asset5AppService.GetAsset5s(asset5Filter);
        }

        [HttpGet]
        public Asset5Input GetAsset5ForEdit(int id)
        {
            return asset5AppService.GetAsset5ForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAsset5([FromBody] Asset5Input input)
        {
            asset5AppService.CreateOrEditAsset5(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAsset5(int id)
        {
            asset5AppService.DeleteAsset5(id);
        }

        [HttpGet]
        public Asset5ForViewDto GetAsset5ForView(int id)
        {
            return asset5AppService.GetAsset5ForView(id);
        }
    }
}
