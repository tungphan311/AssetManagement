using GWebsite.AbpZeroTemplate.Application.Share.ProductDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductDetails
{
    public interface IProductDetailAppService
    {
        void CreateOrEditProductDetail(ProductDetailInput productDetailInput);
        ProductDetailInput FindByFkId(int providerId, int productCategoryId);
    }
}
