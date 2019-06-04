using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Asset5s;
using GWebsite.AbpZeroTemplate.Application.Share.Asset5s.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Asset5s
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class Asset5AppService : GWebsiteAppServiceBase, IAsset5AppService
    {
        private readonly IRepository<Asset5> asset5Repository;

        public Asset5AppService(IRepository<Asset5> asset5Repository)
        {
            this.asset5Repository = asset5Repository;
        }

        public IRepository<Asset5> Asset5Repository => asset5Repository;

        #region Public Method

        public void CreateOrEditAsset5(Asset5Input asset5Input)
        {
            if (asset5Input.Id == 0)
            {
                Create(asset5Input);
            }
            else
            {
                Update(asset5Input);
            }
        }

        public void DeleteAsset5(int id)
        {
            var asset5Entity = Asset5Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset5Entity != null)
            {
                asset5Entity.IsDelete = true;
                Asset5Repository.Update(asset5Entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public Asset5Input GetAsset5ForEdit(int id)
        {
            var asset5Entity = Asset5Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset5Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset5Input>(asset5Entity);
        }

        public Asset5ForViewDto GetAsset5ForView(int id)
        {
            var asset5Entity = Asset5Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset5Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset5ForViewDto>(asset5Entity);
        }

        public PagedResultDto<Asset5Dto> GetAsset5s(Asset5Filter input)
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<Asset5Dto> GetCustomers(Asset5Filter input)
        {
            var query = Asset5Repository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
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
            return new PagedResultDto<Asset5Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<Asset5Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(Asset5Input asset5Input)
        {
            var asset5Entity = ObjectMapper.Map<Asset5>(asset5Input);
            SetAuditInsert(asset5Entity);
            Asset5Repository.Insert(asset5Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(Asset5Input asset5Input)
        {
            var asset5Entity = Asset5Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == asset5Input.Id);
            if (asset5Entity == null)
            {
            }
            ObjectMapper.Map(asset5Input, asset5Entity);
            SetAuditEdit(asset5Entity);
            Asset5Repository.Update(asset5Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
//A//