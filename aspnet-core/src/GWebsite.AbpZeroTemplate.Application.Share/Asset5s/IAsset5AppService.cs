using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset5s.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset5s
{
    public interface IAsset5AppService
    {
        void CreateOrEditAsset5(Asset5Input asset5Input);
        Asset5Input GetAsset5ForEdit(int id);
        void DeleteAsset5(int id);
        PagedResultDto<Asset5Dto> GetAsset5s(Asset5Filter input);
        Asset5ForViewDto GetAsset5ForView(int id);
    }
}
