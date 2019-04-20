using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using GSoft.AbpZeroTemplate.DonVi_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate
{
    public class DonViAppService : AbpZeroTemplateAppServiceBase, IApplicationService
    {
        private readonly IRepository<DonVi> _DonViRepository;

        public DonViAppService(IRepository<DonVi> DonViRepository)
        {
            _DonViRepository = DonViRepository;
        }

        public ListResultDto<DonViDto> GetDonVi(GetDonViInput input)
        {
            var people = _DonViRepository
                .GetAll()
                .WhereIf(!input.Filter.IsNullOrEmpty(), p => p.TenDonVi.ToLower().Equals(input.Filter.ToLower()))
                .ToList();

            return new ListResultDto<DonViDto>(ObjectMapper.Map<List<DonViDto>>(people));
        }

        public async Task DeleteDonVi(EntityDto input)
        {
            await _DonViRepository.DeleteAsync(input.Id);
        }

        public async Task CreateDonVi(CreateDonViInput input)
        {
            //var person = ObjectMapper.Map<Person>(input);
            //await _DonViRepository.InsertAsync(person);
        }

    }

}
