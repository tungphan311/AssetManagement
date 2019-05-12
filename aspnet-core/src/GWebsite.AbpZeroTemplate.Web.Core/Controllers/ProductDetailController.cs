using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ProductDetails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductDetailController : GWebsiteControllerBase
    {
        private readonly IProductDetailAppService productDetailAppService;

        public ProductDetailController(IProductDetailAppService productDetailAppService)
        {
            this.productDetailAppService = productDetailAppService;
        }

        //[HttpGet]
        //public PagedResultDto<ProductDetailDto> GetProductDetailsByFilter(ProductDetailFilter productDetailFilter)
        //{
        //    return productDetailAppService.GetProductDetails(productDetailFilter);
        //}

        //[HttpGet]
        //public ProductDetailInput GetProductDetailForEdit(int id)
        //{
        //    return productDetailAppService.GetProductDetailForEdit(id);
        //}

        [HttpPost]
        public void CreateOrEditProductDetail([FromBody] ProductDetailInput input)
        {
            productDetailAppService.CreateOrEditProductDetail(input);
        }
        [HttpDelete("{id}")]
        public void FindByFkId(int providerId, int productCategoryId)
        {
            productDetailAppService.FindByFkId(providerId, productCategoryId);
        }
        //[HttpDelete("{id}")]
        //public void DeleteProductDetail(int id)
        //{
        //    productDetailAppService.DeleteProductDetail(id);
        //}

        //[HttpGet]
        //public ProductDetailForViewDto GetProductDetailForView(int id)
        //{
        //    return productDetailAppService.GetProductDetailForView(id);
        //}
    }
}
