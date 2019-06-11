using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Retails.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Retails
{
    public interface IRetailAppService
    {
        void CreateOrEditRetail(RetailInput retailInput);
        RetailInput GetRetailForEdit(int id);
        void DeleteRetail(int id);
        PagedResultDto<RetailDto> GetRetails(RetailFilter input);
        RetailForViewDto GetRetailForView(int id);
    }
}
