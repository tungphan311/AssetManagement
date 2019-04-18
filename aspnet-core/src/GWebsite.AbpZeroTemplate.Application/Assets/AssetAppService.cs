using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.Assets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class AssetAppService : GWebsiteAppServiceBase, IAssetAppService
    {
        private readonly IRepository<Customer> customerRepository;

        public AssetAppService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }
          #region Public Method

        public void CreateOrEditAsset(AssetInput assetInput)
        {
            if (assetInput.Id == 0)
            {
                Create(assetInput);
            }
            else
            {
                Update(assetInput);
            }
        }

      

        public void DeleteAsset(int id)
        {
            var customerEntity = customerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (customerEntity != null)
            {
                customerEntity.IsDelete = true;
                customerRepository.Update(customerEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public PagedResultDto<AssetDto> GetAsset(AssetFilter input)
        {
            throw new System.NotImplementedException();
        }

        public AssetInput GetCustomerForEdit(int id)
        {
            var customerEntity = customerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (customerEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetInput>(customerEntity);
        }

        public AssetForView GetCustomerForView(int id)
        {
            var customerEntity = customerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (customerEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetForView>(customerEntity);
        }

        public PagedResultDto<AssetDto> GetCustomers(AssetFilter input)
        {
            var query = customerRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.nameAsset != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.nameAsset));
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
            return new PagedResultDto<AssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetDto>(item)).ToList());
        }

        #endregion

         #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(AssetInput customerInput)
        {
            var customerEntity = ObjectMapper.Map<Customer>(customerInput);
            SetAuditInsert(customerEntity);
            customerRepository.Insert(customerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        AssetInput IAssetAppService.getAssetForEdit(int id)
        {
            throw new System.NotImplementedException();
        }

        AssetForView IAssetAppService.GetAssetForView(int id)
        {
            throw new System.NotImplementedException();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(AssetInput customerInput)
        {
            var customerEntity = customerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == customerInput.Id);
            if (customerEntity == null)
            {
            }
            ObjectMapper.Map(customerInput, customerEntity);
            SetAuditEdit(customerEntity);
            customerRepository.Update(customerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }

}



