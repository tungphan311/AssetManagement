using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductCategories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductCategories
{
    public interface IProductCategoryAppService
    {
        void CreateOrEditProductCategory(ProductCategoryInput productCategoryInput);
        ProductCategoryInput GetProductCategoryForEdit(int id);
        void DeleteProductCategory(int id);
        PagedResultDto<ProductCategoryDto> GetProductCategories(ProductCategoryFilter input);
        ProductCategoryForViewDto GetProductCategoryForView(int id);
    }
}
