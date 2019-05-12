
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductCategories;
using GWebsite.AbpZeroTemplate.Application.Share.ProductCategories.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductCategoryController : GWebsiteControllerBase
    {
        private readonly IProductCategoryAppService productCategoryAppService;

        public ProductCategoryController(IProductCategoryAppService productCategoryAppService)
        {
            this.productCategoryAppService = productCategoryAppService;
        }

        [HttpGet]
        public PagedResultDto<ProductCategoryDto> GetProductCategoriesByFilter(ProductCategoryFilter productCategoryFilter)
        {
            return productCategoryAppService.GetProductCategories(productCategoryFilter);
        }

        [HttpGet]
        public ProductCategoryInput GetProductCategoryForEdit(int id)
        {
            return productCategoryAppService.GetProductCategoryForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditProductCategory([FromBody] ProductCategoryInput input)
        {
            productCategoryAppService.CreateOrEditProductCategory(input);
        }

        [HttpDelete("{id}")]
        public void DeleteProductCategory(int id)
        {
            productCategoryAppService.DeleteProductCategory(id);
        }

        [HttpGet]
        public ProductCategoryForViewDto GetProductCategoryForView(int id)
        {
            return productCategoryAppService.GetProductCategoryForView(id);
        }
    }
}
