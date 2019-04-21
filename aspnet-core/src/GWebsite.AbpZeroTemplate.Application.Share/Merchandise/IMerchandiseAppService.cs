using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AutoMapper;
using GSoft.AbpZeroTemplate;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandise.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandise
{
    public interface IMerchandiseAppService: IApplicationService
    {
        ListResultDto<MerchandiseListDto> GetMerchandise(GetMerchandiseInput input);
        Task<MerchandiseDto> CreateMerchandise(CreateMerchandiseInput input);
        Task DeleteMerchandise(EntityDto<int> input);
    }

}
