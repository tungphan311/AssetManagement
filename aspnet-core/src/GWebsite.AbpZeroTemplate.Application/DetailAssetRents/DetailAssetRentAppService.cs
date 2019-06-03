using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents;
using GWebsite.AbpZeroTemplate.Application.Share.DetailAssetRents.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.DetailAssetRents
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class DetailAssetRentAppService : GWebsiteAppServiceBase, IDetailAssetRentAppService
    {
        private readonly IRepository<DetailAssetRent> detailAssetRentRepository;

        public DetailAssetRentAppService(IRepository<DetailAssetRent> detailAssetRentRepository)
        {
            this.detailAssetRentRepository = detailAssetRentRepository;
        }
        #region Public Method

        public void CreateOrEditDetailAssetRent(DetailAssetRentInput detailAssetRentInput)
        {
            if (detailAssetRentInput.Id == 0)
            {
                Create(detailAssetRentInput);
            }
            else
            {
                Update(detailAssetRentInput);
            }
        }



        public void DeleteDetailAssetRent(int id)
        {
            var detailAssetRentEntity = detailAssetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (detailAssetRentEntity != null)
            {
                detailAssetRentEntity.IsDelete = true;
                detailAssetRentRepository.Update(detailAssetRentEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DetailAssetRentInput GetDetailAssetRentForEdit(int id)
        {
            var detailAssetRentEntity = detailAssetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (detailAssetRentEntity == null)
            {

                return null;
            }
            return ObjectMapper.Map<DetailAssetRentInput>(detailAssetRentEntity);
        }

        public DetailAssetRentForView GetDetailAssetRentForView(int id)
        {
            var detailAssetRentEntity = detailAssetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (detailAssetRentEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DetailAssetRentForView>(detailAssetRentEntity);
        }

        public PagedResultDto<DetailAssetRentDto> GetDetailAssetRent(DetailAssetRentFilter input)
        {
            var query = detailAssetRentRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<DetailAssetRentDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DetailAssetRentDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(DetailAssetRentInput detailAssetRentInput)
        {
            var detailAssetRentEntity = ObjectMapper.Map<DetailAssetRent>(detailAssetRentInput);
            SetAuditInsert(detailAssetRentEntity);
            detailAssetRentRepository.Insert(detailAssetRentEntity);
            CurrentUnitOfWork.SaveChanges();
        }


        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(DetailAssetRentInput detailAssetRentInput)
        {
            var detailAssetRentEntity = detailAssetRentRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == detailAssetRentInput.Id);
            if (detailAssetRentEntity == null)
            {
            }
            ObjectMapper.Map(detailAssetRentInput, detailAssetRentEntity);
            SetAuditEdit(detailAssetRentEntity);
            detailAssetRentRepository.Update(detailAssetRentEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }

}





