using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Vendors;
using GWebsite.AbpZeroTemplate.Application.Share.Vendors.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Vendors
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VendorAppService : GWebsiteAppServiceBase, IVendorAppService
    {
        private readonly IRepository<Vendor> vendorRepository;

        public VendorAppService(IRepository<Vendor> vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        #region Public Method

        public void CreateOrEditVendor(VendorInput vendorInput)
        {
            if (vendorInput.Id == 0)
            {
                Create(vendorInput);
            }
            else
            {
                Update(vendorInput);
            }
        }

        public void DeleteVendor(int id)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendorEntity != null)
            {
                vendorEntity.IsDelete = true;
                vendorRepository.Update(vendorEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VendorInput GetVendorForEdit(int id)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendorEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VendorInput>(vendorEntity);
        }

        public VendorForViewDto GetVendorForView(int id)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendorEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VendorForViewDto>(vendorEntity);
        }

        public PagedResultDto<VendorDto> GetVendors(VendorFilter input)
        {
            var query = vendorRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<VendorDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VendorDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VendorInput vendorInput)
        {
            var vendorEntity = ObjectMapper.Map<Vendor>(vendorInput);
            SetAuditInsert(vendorEntity);
            vendorRepository.Insert(vendorEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VendorInput vendorInput)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vendorInput.Id);
            if (vendorEntity == null)
            {
            }
            ObjectMapper.Map(vendorInput, vendorEntity);
            SetAuditEdit(vendorEntity);
            vendorRepository.Update(vendorEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
