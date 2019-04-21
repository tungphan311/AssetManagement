using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandise;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandise.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Merchandise)]
    public class MerchandiseAppService : GWebsiteAppServiceBase, IMerchandiseAppService
    {
        private readonly IRepository<Merchandise> _merchandiseRepository;

        public MerchandiseAppService(IRepository<Merchandise> merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Merchandise_Create)]
        public async Task<MerchandiseDto> CreateMerchandise(CreateMerchandiseInput input)
        {
            var merchandise = ObjectMapper.Map<Merchandise>(input);
            merchandise = await  _merchandiseRepository.InsertAsync(merchandise);
            return ObjectMapper.Map<MerchandiseDto>(merchandise);
        }

        public async Task DeleteMerchandise(EntityDto<int> input)
        {
            await _merchandiseRepository.DeleteAsync(input.Id);
        }

        public ListResultDto<MerchandiseListDto> GetMerchandise(GetMerchandiseInput input)
        {
            var merchandise = _merchandiseRepository
            .GetAll()
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                     p.Info.Contains(input.Filter)
            )
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Info)
            .ToList();

            return new ListResultDto<MerchandiseListDto>(ObjectMapper.Map<List<MerchandiseListDto>>(merchandise));
        }
    }
}
