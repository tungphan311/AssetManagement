using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ProductCategories;
using GWebsite.AbpZeroTemplate.Application.Share.ProductCategories.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ProductCategoryCategories
{
    public class ProductCategoryAppService : GWebsiteAppServiceBase, IProductCategoryAppService
    {
        private readonly IRepository<ProductCategory> productCategoryRepository;

        public ProductCategoryAppService(IRepository<ProductCategory> productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        #region Public Method

        public void CreateOrEditProductCategory(ProductCategoryInput productCategoryInput)
        {
            if (productCategoryInput.Id == 0)
            {
                Create(productCategoryInput);
            }
            else
            {
                Update(productCategoryInput);
            }
        }

        public void DeleteProductCategory(int id)
        {
            var productCategoryEntity = productCategoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (productCategoryEntity != null)
            {
                productCategoryEntity.IsDelete = true;
                productCategoryRepository.Update(productCategoryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ProductCategoryInput GetProductCategoryForEdit(int id)
        {
            var productCategoryEntity = productCategoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (productCategoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductCategoryInput>(productCategoryEntity);
        }

        public ProductCategoryForViewDto GetProductCategoryForView(int id)
        {
            try
            {
                var productCategoryEntity = productCategoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
                if (productCategoryEntity == null)
                {
                    Console.WriteLine("ProductCategory with id=" + id.ToString() + " is null");
                    return null;
                }
                return ObjectMapper.Map<ProductCategoryForViewDto>(productCategoryEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception ProductCategory for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<ProductCategoryDto> GetProductCategories(ProductCategoryFilter input)
        {
            var query = productCategoryRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(input.Name));
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
            return new PagedResultDto<ProductCategoryDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductCategoryDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductCategory_Create)]
        private void Create(ProductCategoryInput productCategoryInput)
        {
            System.Console.WriteLine("ProductCategoryInput: " + productCategoryInput.Name.ToString());
            try
            {
                var productCategoryEntity = ObjectMapper.Map<ProductCategory>(productCategoryInput);
                if (productCategoryEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(productCategoryEntity);
                productCategoryRepository.Insert(productCategoryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductCategory_Edit)]
        private void Update(ProductCategoryInput productCategoryInput)
        {
            var productCategoryEntity = productCategoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == productCategoryInput.Id);
            if (productCategoryEntity == null)
            {
            }
            ObjectMapper.Map(productCategoryInput, productCategoryEntity);
            SetAuditEdit(productCategoryEntity);
            productCategoryRepository.Update(productCategoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
