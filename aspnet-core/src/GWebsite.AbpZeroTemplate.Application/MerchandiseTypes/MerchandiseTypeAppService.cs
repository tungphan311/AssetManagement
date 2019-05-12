using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes;
using GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Web.Core.MerchandiseTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class MerchandiseTypeAppService : GWebsiteAppServiceBase, IMerchandiseTypeAppService
    {
        private readonly IRepository<MerchandiseType> merchandiseTypeRepository;

        public MerchandiseTypeAppService(IRepository<MerchandiseType> repository)
        {
            merchandiseTypeRepository = repository;
        }

        #region public method
        public void CreateOrEditMerchandiseType(MerchandiseTypeInput input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Update(input);
            }
        }

        public void DeleteMerchandiseType(int id)
        {
            var merchandiseTypeEntity = merchandiseTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (merchandiseTypeEntity != null)
            {
                merchandiseTypeEntity.IsDelete = true;
                merchandiseTypeRepository.Update(merchandiseTypeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public MerchandiseTypeInput GetMerchandiseTypeForEdit(int id)
        {
            var merchandiseTypeEntity = merchandiseTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (merchandiseTypeEntity == null)
            {
                return null;
            }

            return ObjectMapper.Map<MerchandiseTypeInput>(merchandiseTypeEntity);
        }

        public MerchandiseTypeForViewDto GetMerchandiseTypeForView(int id)
        {
            var merchandiseTypeEntity = merchandiseTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (merchandiseTypeEntity == null)
            {
                return null;
            }

            return ObjectMapper.Map<MerchandiseTypeForViewDto>(merchandiseTypeEntity);
        }

        public PagedResultDto<MerchandiseTypeDto> GetMerchandiseTypes(MerchandiseTypeFilter input)
        {
            var query = merchandiseTypeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by typeID
            if (input.TypeID != null)
            {
                query = query.Where(x => x.TypeID.ToLower().Contains(input.TypeID));
            }

            // filter by name
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name));
            }

            // filter by isActive
            if (input.IsActive != null)
            {
                if (input.IsActive.Equals(("True").ToLower()))
                {
                    query = query.Where(x => x.IsActive == true);
                }
                else if (input.IsActive.Equals(("False").ToLower()))
                {
                    query = query.Where(x => x.IsActive == false);
                }
            }                 
            
            var totalCount = query.Count();

            // sort
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result 
            return new PagedResultDto<MerchandiseTypeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<MerchandiseTypeDto>(item)).ToList());
        }
        #endregion

        #region private method 

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(MerchandiseTypeInput input)
        {
            var merchandiseTypeEntity = ObjectMapper.Map<MerchandiseType>(input);
            SetAuditInsert(merchandiseTypeEntity);
            merchandiseTypeRepository.Insert(merchandiseTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        } 

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(MerchandiseTypeInput input)
        {
            var merchandiseTypeEntity = merchandiseTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (merchandiseTypeEntity == null)
            {

            }
            ObjectMapper.Map(input, merchandiseTypeEntity);
            SetAuditEdit(merchandiseTypeEntity);
            merchandiseTypeRepository.Update(merchandiseTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
