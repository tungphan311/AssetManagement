using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.VendorTypes;
using GWebsite.AbpZeroTemplate.Application.Share.VendorTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.VendorTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VendorTypeAppService : GWebsiteAppServiceBase, IVendorTypeAppService
    {
        private readonly IRepository<VendorType> vendortypeRepository;

        public VendorTypeAppService(IRepository<VendorType> vendortypeRepository)
        {
            this.vendortypeRepository = vendortypeRepository;
        }

        #region Public Method

        public void CreateOrEditVendorType(VendorTypeInput vendortypeInput)
        {
            if (vendortypeInput.Id == 0)
            {
                Create(vendortypeInput);
            }
            else
            {
                Update(vendortypeInput);
            }
        }

        public void DeleteVendorType(int id)
        {
            var vendortypeEntity = vendortypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendortypeEntity != null)
            {
                vendortypeEntity.IsDelete = true;
                vendortypeRepository.Update(vendortypeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VendorTypeInput GetVendorTypeForEdit(int id)
        {
            var vendortypeEntity = vendortypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendortypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VendorTypeInput>(vendortypeEntity);
        }

        public VendorTypeForViewDto GetVendorTypeForView(int id)
        {
            var vendortypeEntity = vendortypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendortypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VendorTypeForViewDto>(vendortypeEntity);
        }

        public PagedResultDto<VendorTypeDto> GetVendorTypes(VendorTypeFilter input)
        {
            var query = vendortypeRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<VendorTypeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VendorTypeDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VendorTypeInput vendortypeInput)
        {
            var vendortypeEntity = ObjectMapper.Map<VendorType>(vendortypeInput);
            SetAuditInsert(vendortypeEntity);
            vendortypeRepository.Insert(vendortypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VendorTypeInput vendortypeInput)
        {
            var vendortypeEntity = vendortypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vendortypeInput.Id);
            if (vendortypeEntity == null)
            {
            }
            ObjectMapper.Map(vendortypeInput, vendortypeEntity);
            SetAuditEdit(vendortypeEntity);
            vendortypeRepository.Update(vendortypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
