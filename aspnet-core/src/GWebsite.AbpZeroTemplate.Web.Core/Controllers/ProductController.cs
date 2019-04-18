using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : GWebsiteControllerBase
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        public PagedResultDto<ProductDto> GetProductsByFilter(ProductFilter productFilter)
        {
            return productAppService.GetProducts(productFilter);
        }

        [HttpGet]
        public ProductInput GetProductForEdit(int id)
        {
            return productAppService.GetProductForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditProduct([FromBody] ProductInput input)
        {
            productAppService.CreateOrEditProduct(input);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            productAppService.DeleteProduct(id);
        }

        [HttpGet]
        public ProductForViewDto GetCustomerForView(int id)
        {
            return productAppService.GetProductForView(id);
        }
    }
}
