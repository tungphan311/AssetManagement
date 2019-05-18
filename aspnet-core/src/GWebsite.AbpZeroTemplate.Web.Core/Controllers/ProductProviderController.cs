using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductProviders;
using GWebsite.AbpZeroTemplate.Application.Share.ProductProviders.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductProviderController : GWebsiteControllerBase
    {
        private readonly IProductProviderAppService ProductProviderAppService;

        public ProductProviderController(IProductProviderAppService ProductProviderAppService)
        {
            this.ProductProviderAppService = ProductProviderAppService;
        }

        //[HttpGet]
        //public PagedResultDto<ProductProviderDto> GetProductProvidersByFilter(ProductProviderFilter ProductProviderFilter)
        //{
        //    return ProductProviderAppService.GetProductProviders(ProductProviderFilter);
        //}

        [HttpGet]
        public ProductProviderInput GetProductProviderForEdit(int id)
        {
            return ProductProviderAppService.GetProductProviderForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditProductProvider([FromBody] ProductProviderInput input)
        {
            ProductProviderAppService.CreateOrEditProductProvider(input);
        }

        //[HttpDelete("{id}")]
        //public void DeleteProductProvider(int id)
        //{
        //    ProductProviderAppService.DeleteProductProvider(id);
        //}

        //[HttpGet]
        //public ProductProviderForViewDto GetProductProviderForView(int id)
        //{
        //    return ProductProviderAppService.GetProductProviderForView(id);
        //}
    }
}
