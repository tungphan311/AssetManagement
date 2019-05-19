using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductContracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductContracts
{
    public interface IProductContractAppService
    {
        void CreateOrEditProductContract(ProductContractInput ProductContractInput);
        ProductContractInput GetProductContractForEdit(int id);
        void DeleteProductContract(int id);
        void DeleteMultiProductContract(int ContractPaymentId);
        PagedResultDto<ProductContractDto> GetProductContracts(ProductContractFilter input);
        ProductContractForViewDto GetProductContractForView(int id);
    }
}
