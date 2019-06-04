using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSanThueS.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.TaiSanThueS
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class TSThueAppService : GWebsiteAppServiceBase, ITSThueAppService
    {
        private readonly IRepository<TaiSanThue> tstRepository;

        public TSThueAppService(IRepository<TaiSanThue> tstRepository)
        {
            this.tstRepository = tstRepository;
        }

        #region Public Method

        public void CreateOrEditTSThue(TSThueInput tstInput)
        {
            if (tstInput.Id == 0)
            {
                Create(tstInput);
            }
            else
            {
                Update(tstInput);
            }
        }

         public void DeleteTSThue(int id)
        {
            var tstEntity = tstRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tstEntity != null)
            {
                tstEntity.IsDelete = true;
                tstRepository.Update(tstEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public PagedResultDto<TaiSanThueDto> GetTSThue(TSThueFilter input)
        {
            var query = tstRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaTaiSan != null)
            {
                query = query.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
            }
            if (input.TenTaiSan != null)
            {
                query = query.Where(x => x.TenTaiSan.ToLower().Equals(input.TenTaiSan));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<TaiSanThueDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TaiSanThueDto>(item)).ToList());
        }

        public TSThueInput GetTSThueForEdit(int id)
        {
            var tstEntity = tstRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tstEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TSThueInput>(tstEntity);
        }

        public TSThueForViewDto GetTSThueForView(int id)
        {
            var tstEntity = tstRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tstEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TSThueForViewDto>(tstEntity);
        }

        

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(TSThueInput tstInput)
        {
            var tstEntity = ObjectMapper.Map<TaiSanThue>(tstInput);
            SetAuditInsert(tstEntity);
            tstRepository.Insert(tstEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(TSThueInput tstInput)
        {
            var tstEntity = tstRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == tstInput.Id);
            if (tstEntity == null)
            {
            }
            ObjectMapper.Map(tstInput, tstEntity);
            SetAuditEdit(tstEntity);
            tstRepository.Update(tstEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}