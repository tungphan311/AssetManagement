using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductContracts;
using GWebsite.AbpZeroTemplate.Application.Share.ProductContracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductContractController : GWebsiteControllerBase
    {
        private readonly IProductContractAppService productContractAppService;

        public ProductContractController(IProductContractAppService productContractAppService)
        {
            this.productContractAppService = productContractAppService;
        }

        [HttpGet]
        public PagedResultDto<ProductContractDto> GetProductContractsByFilter(ProductContractFilter ProductContractFilter)
        {
            return productContractAppService.GetProductContracts(ProductContractFilter);
        }

        [HttpGet]
        public ProductContractInput GetProductContractForEdit(int id)
        {
            return productContractAppService.GetProductContractForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditProductContract([FromBody] ProductContractInput input)
        {
            productContractAppService.CreateOrEditProductContract(input);
        }

        [HttpDelete("{id}")]
        public void DeleteProductContract(int id)
        {
            productContractAppService.DeleteProductContract(id);
        }
        [HttpDelete("{contractId}")]
        public void DeleteMultiProductContract(int contractId)
        {
            productContractAppService.DeleteMultiProductContract(contractId);
        }

        [HttpGet]
        public ProductContractForViewDto GetProductContractForView(int id)
        {
            return productContractAppService.GetProductContractForView(id);
        }
    }
}
