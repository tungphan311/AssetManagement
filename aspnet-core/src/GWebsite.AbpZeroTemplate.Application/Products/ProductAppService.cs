using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Products;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Products
{
    public class ProductAppService : GWebsiteAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product> productRepository;

        public ProductAppService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        #region Public Method

        public void CreateOrEditProduct(ProductInput productInput)
        {
            if (productInput.Id == 0)
            {
                Create(productInput);
            }
            else
            {
                Update(productInput);
            }
        }

        public void DeleteProduct(int id)
        {
            var productEntity = productRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (productEntity != null)
            {
                productEntity.IsDelete = true;
                productRepository.Update(productEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ProductInput GetProductForEdit(int id)
        {
            var productEntity = productRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (productEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductInput>(productEntity);
        }

        public ProductForViewDto GetProductForView(int id)
        {
            var productEntity = productRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (productEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductForViewDto>(productEntity);
        }

        public PagedResultDto<ProductDto> GetProducts(ProductFilter input)
        {
            var query = productRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<ProductDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product_Create)]
        private void Create(ProductInput productInput)
        {
            var productEntity = ObjectMapper.Map<Product>(productInput);
            SetAuditInsert(productEntity);
            productRepository.Insert(productEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product_Edit)]
        private void Update(ProductInput productInput)
        {
            var productEntity = productRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == productInput.Id);
            if (productEntity == null)
            {
            }
            ObjectMapper.Map(productInput, productEntity);
            SetAuditEdit(productEntity);
            productRepository.Update(productEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
