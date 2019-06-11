using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.POMerchandises;
using GWebsite.AbpZeroTemplate.Application.Share.POMerchandises.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.POMerchandises
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class POMerchandiseAppService : GWebsiteAppServiceBase, IPOMerchandiseAppService
    {
        private readonly IRepository<POMerchandise> repository;

        public POMerchandiseAppService(IRepository<POMerchandise> repository)
        {
            this.repository = repository;
        }

        #region public method

        public void CreateOrEditPOMerchandise(POMerchandiseInput input)
        {
            throw new NotImplementedException();
        }

        public void DeletePOMerchandise(int id)
        {
            throw new NotImplementedException();
        }

        public POMerchandiseInput GetPOMerchandiseForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public POMerchandiseForViewDto GetPOMerchandiseForView(int id)
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<POMerchandiseDto> GetPOs(POMerchandiseFilter input)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private method

        #endregion
    }
}
