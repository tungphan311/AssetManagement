using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRents;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRents.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetsRents.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;


namespace GWebsite.AbpZeroTemplate.Web.Core.AssetRents
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class AssetRentAppService : GWebsiteAppServiceBase, IAssetRentAppService
    {
        private readonly IRepository<AsssetRent> assetRentRepository;

        public AssetRentAppService(IRepository<AsssetRent> assetRentRepository)
        {
            this.assetRentRepository = assetRentRepository;
        }
        #region Public Method

        public void CreateOrEditAssetRent(AssetRentInput assetRentInput)
        {
           
            if (assetRentInput.Id == 0)
            {
                Create(assetRentInput);
            }
            else
            {
                Update(assetRentInput);
            }
        }



        public void DeleteAssetRent(int id)
        {
            var assetRentEntity = assetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentEntity != null)
            {
                assetRentEntity.IsDelete = true;
                assetRentRepository.Update(assetRentEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public PagedResultDto<AssetRentDto> GetAssetRent(AssetRentFilter input)

        {
            var query = assetRentRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.nameAsset != null || input.rentBy != null)
            {
                query = query.Where(x => (x.nameAsset.ToLower().Equals(input.nameAsset) || (x.rentBy.ToLower().Equals(input.rentBy))));                
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
            return new PagedResultDto<AssetRentDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetRentDto>(item)).ToList());
            throw new System.NotImplementedException();
        }

        public AssetRentInput GetAssetRentForEdit(int id)
        {
            var assetRentEntity = assetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetRentInput>(assetRentEntity);
        }

        public AssetRentForView GetAssetRentForView(int id)
        {
            var assetRentEntity = assetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetRentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetRentForView>(assetRentEntity);
        }



        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(AssetRentInput assetRentInput)
        {
            var assetRentEntity = ObjectMapper.Map<AsssetRent>(assetRentInput);
            SetAuditInsert(assetRentEntity);
            assetRentRepository.Insert(assetRentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(AssetRentInput assetRentInput)
        {
            var assetRentEntity = assetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetRentInput.Id);
            if (assetRentEntity == null)
            {
            }
            ObjectMapper.Map(assetRentInput, assetRentEntity);
            SetAuditEdit(assetRentEntity);
            assetRentRepository.Update(assetRentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }

}



