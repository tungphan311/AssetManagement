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
using GWebsite.AbpZeroTemplate.Application.Share.Merchandises.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandise
{
    public interface IMerchandiseAppService: IApplicationService
    {
        void CreateOrEditMerchandise(MerchandiseInput input);
        MerchandiseInput GetMerchandiseForEdit(int id);
        void DeleteMerchandise(int id);
        PagedResultDto<MerchandiseDto> GetMerchandises(MerchandiseFilter input);
        MerchandiseForViewDto GetMerchandiseForView(int id);
    }

}
