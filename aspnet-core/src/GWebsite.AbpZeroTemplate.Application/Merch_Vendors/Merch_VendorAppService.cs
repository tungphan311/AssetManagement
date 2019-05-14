using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors;
using GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Merch_Vendors
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class Merch_VendorAppService : GWebsiteAppServiceBase, IMerch_VendorAppService
    {
        private readonly IRepository<Merch_Vendor> merchvendorRepository;

        public Merch_VendorAppService(IRepository<Merch_Vendor> merchvendorRepository)
        {
            this.merchvendorRepository = merchvendorRepository;
        }

        #region Public Method

        public void CreateOrEditMerch_Vendor(Merch_VendorInput merchvendorInput)
        {
            if (merchvendorInput.Id == 0)
            {
                Create(merchvendorInput);
            }
            else
            {
                Update(merchvendorInput);
            }
        }

        public void DeleteMerch_Vendor(int id)
        {
            var merchvendorEntity = merchvendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (merchvendorEntity != null)
            {
                merchvendorEntity.IsDelete = true;
                merchvendorRepository.Update(merchvendorEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public Merch_VendorInput GetMerch_VendorForEdit(int id)
        {
            var merchvendorEntity = merchvendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (merchvendorEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Merch_VendorInput>(merchvendorEntity);
        }


        public PagedResultDto<Merch_VendorDto> GetMerch_Vendors(Merch_VendorFilter input)
        {
            var query = merchvendorRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.VendorID != 0)
            {
                query = query.Where(x => x.VendorID == input.VendorID);
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
            return new PagedResultDto<Merch_VendorDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<Merch_VendorDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(Merch_VendorInput merchvendorInput)
        {
            var merchvendorEntity = ObjectMapper.Map<Merch_Vendor>(merchvendorInput);
            SetAuditInsert(merchvendorEntity);
            merchvendorRepository.Insert(merchvendorEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(Merch_VendorInput merchvendorInput)
        {
            var merchvendorEntity = merchvendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == merchvendorInput.Id);
            if (merchvendorEntity == null)
            {
            }
            ObjectMapper.Map(merchvendorInput, merchvendorEntity);
            SetAuditEdit(merchvendorEntity);
            merchvendorRepository.Update(merchvendorEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
