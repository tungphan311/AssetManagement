using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandise;
using GWebsite.AbpZeroTemplate.Application.Share.Merchandises.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.Merchandises
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class MerchandiseAppService : GWebsiteAppServiceBase, IMerchandiseAppService
    {
        private readonly IRepository<Merchandise> merchandiseRepository;

        public MerchandiseAppService(IRepository<Merchandise> repository)
        {
            merchandiseRepository = repository;
        }

        #region public method

        public void CreateOrEditMerchandise(MerchandiseInput input)
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

        public void DeleteMerchandise(int id)
        {
            var merchandiseEntity = merchandiseRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (merchandiseEntity != null)
            {
                merchandiseEntity.IsDelete = true;
                merchandiseRepository.Update(merchandiseEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public MerchandiseInput GetMerchandiseForEdit(int id)
        {
            var merchandiseEntity = merchandiseRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (merchandiseEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<MerchandiseInput>(merchandiseEntity);
        }

        public MerchandiseForViewDto GetMerchandiseForView(int id)
        {
            var merchandiseEntity = merchandiseRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (merchandiseEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<MerchandiseForViewDto>(merchandiseEntity);
        }

        public PagedResultDto<MerchandiseDto> GetMerchandises(MerchandiseFilter input)
        {
            var query = merchandiseRepository.GetAll().Where(x => !x.IsDelete);

            // filter by code 
            if (input.Code != null)
            {
                query = query.Where(x => x.Code.ToLower().Contains(input.Code.ToLower()));
            }

            //filter by name 
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name.ToLower()));
            }

            // filter by typeID
            if (input.TypeID != 0)
            {
                query = query.Where(x => x.TypeID == input.TypeID);
            }

            // filter by type vender
            if (input.TypeVender != 0)
            {
                query = query.Where(x => x.TypeVender == input.TypeVender);
            }

            // filter by isActive 
            if (input.IsActive != null)
            {
                if (input.IsActive.Equals("True"))
                {
                    query = query.Where(x => x.IsActive == true);
                }
                else if (input.IsActive.Equals("False"))
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
            return new PagedResultDto<MerchandiseDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<MerchandiseDto>(item)).ToList());
        }
        #endregion

        #region private method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(MerchandiseInput input)
        {
            var merchandiseEntity = ObjectMapper.Map<Merchandise>(input);
            SetAuditInsert(merchandiseEntity);
            merchandiseRepository.Insert(merchandiseEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(MerchandiseInput input)
        {
            var merchandiseEntity = merchandiseRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (merchandiseEntity == null)
            {

            }
            ObjectMapper.Map(input, merchandiseEntity);
            SetAuditEdit(merchandiseEntity);
            merchandiseRepository.Update(merchandiseEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
