using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ProductDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ProductDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ProductDetails
{
    public class ProductDetailAppService : GWebsiteAppServiceBase, IProductDetailAppService
    {
        private readonly IRepository<ProductDetail> productDetailRepository;

        public ProductDetailAppService(IRepository<ProductDetail> productDetailRepository)
        {
            this.productDetailRepository = productDetailRepository;
        }

        #region Public Method

        public void CreateOrEditProductDetail(ProductDetailInput productDetailInput)
        {
            if (productDetailInput.Id == 0)
            {
                Create(productDetailInput);
            }
            else
            {
                Update(productDetailInput);
            }
        }

        public ProductDetailInput FindByFkId(int providerId, int productCategoryId)
        {
            var result = ObjectMapper.Map<ProductDetailInput>(productDetailRepository.FirstOrDefault(x => x.ProductCategoryId == productCategoryId
                                                      && x.ProviderId == providerId));
            return result;
        }

        public ProductDetailInput GetProductDetailForEdit(int id)
        {
            var productDetailEntity = productDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
            if (productDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductDetailInput>(productDetailEntity);
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductDetail_Create)]
        private void Create(ProductDetailInput productDetailInput)
        {
            try
            {
                var productDetailEntity = ObjectMapper.Map<ProductDetail>(productDetailInput);
                if (productDetailEntity == null) System.Console.WriteLine("null: ");
                productDetailRepository.Insert(productDetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductDetail_Edit)]
        private void Update(ProductDetailInput productDetailInput)
        {
            var productDetailEntity = productDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == productDetailInput.Id);
            if (productDetailEntity == null)
            {
            }
            ObjectMapper.Map(productDetailInput, productDetailEntity);
            //SetAuditEdit(productDetailEntity);
            productDetailRepository.Update(productDetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
