using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ProductProviders;
using GWebsite.AbpZeroTemplate.Application.Share.ProductProviders.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ProductProviders
{
    public class ProductProviderAppService : GWebsiteAppServiceBase, IProductProviderAppService
    {
        private readonly IRepository<ProductProvider> ProductProviderRepository;

        public ProductProviderAppService(IRepository<ProductProvider> ProductProviderRepository)
        {
            this.ProductProviderRepository = ProductProviderRepository;
        }

        #region Public Method

        public void CreateOrEditProductProvider(ProductProviderInput ProductProviderInput)
        {

            if (ProductProviderInput.Id == 0)
            {
                Create(ProductProviderInput);
            }
            else
            {
                Update(ProductProviderInput);
            }
        }

        //public void DeleteProductProvider(int id)
        //{
        //    var ProductProviderEntity = ProductProviderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
        //    if (ProductProviderEntity != null)
        //    {
        //        ProductProviderEntity.IsDelete = true;
        //        ProductProviderRepository.Update(ProductProviderEntity);
        //        CurrentUnitOfWork.SaveChanges();
        //    }
        //}

        public ProductProviderInput GetProductProviderForEdit(int id)
        {
            var ProductProviderEntity = ProductProviderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductProviderEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductProviderInput>(ProductProviderEntity);
        }

        //public ProductProviderForViewDto GetProductProviderForView(int id)
        //{
        //    try
        //    {
        //        var ProductProviderEntity = ProductProviderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
        //        if (ProductProviderEntity == null)
        //        {
        //            Console.WriteLine("ProductProvider with id=" + id.ToString() + " is null");
        //            return null;
        //        }
        //        return ObjectMapper.Map<ProductProviderForViewDto>(ProductProviderEntity);
        //    }
        //    catch (Exception e) { Console.WriteLine("Exception ProductProvider for View: " + e.ToString()); return null; }
        //}

        //public PagedResultDto<ProductProviderDto> GetProductProviders(ProductProviderFilter input)
        //{
        //    var query = ProductProviderRepository.GetAll().Where(x => !x.IsDelete);

        //    // filter by value
        //    if (input.Name != null)
        //    {
        //        query = query.Where(x => x.Name.ToLower().StartsWith(input.Name));
        //    }

        //    var totalCount = query.Count();

        //    // sorting
        //    if (!string.IsNullOrWhiteSpace(input.Sorting))
        //    {
        //        query = query.OrderBy(input.Sorting);
        //    }

        //    // paging
        //    var items = query.PageBy(input).ToList();

        //    // result
        //    return new PagedResultDto<ProductProviderDto>(
        //        totalCount,
        //        items.Select(item => ObjectMapper.Map<ProductProviderDto>(item)).ToList());
        //}

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductProvider_Create)]
        private void Create(ProductProviderInput ProductProviderInput)
        {

            try
            {
                var ProductProviderEntity = ObjectMapper.Map<ProductProvider>(ProductProviderInput);
                if (ProductProviderEntity == null) System.Console.WriteLine("null: ");
                //SetAuditInsert(ProductProviderEntity);
                ProductProviderRepository.Insert(ProductProviderEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductProvider_Edit)]
        private void Update(ProductProviderInput ProductProviderInput)
        {
            var ProductProviderEntity = ProductProviderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ProductProviderInput.Id);
            if (ProductProviderEntity == null)
            {
            }
            ObjectMapper.Map(ProductProviderInput, ProductProviderEntity);
            //SetAuditEdit(ProductProviderEntity);
            ProductProviderRepository.Update(ProductProviderEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
