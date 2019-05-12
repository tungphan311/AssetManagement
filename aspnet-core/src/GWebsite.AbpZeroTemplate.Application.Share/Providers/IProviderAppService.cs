using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Providers
{
    public interface IProviderAppService
    {
        void CreateOrEditProvider(ProviderInput providerInput);
        ProviderInput GetProviderForEdit(int id);
        void DeleteProvider(int id);
        PagedResultDto<ProviderDto> GetProviders(ProviderFilter input);
        ProviderForViewDto GetProviderForView(int id);
    }
}
