using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductProviders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductProviders
{
    public interface IProductProviderAppService
    {
        void CreateOrEditProductProvider(ProductProviderInput ProductProviderInput);
        ProductProviderInput GetProductProviderForEdit(int id);
        //void DeleteProductProvider(int id);       
    }
}
