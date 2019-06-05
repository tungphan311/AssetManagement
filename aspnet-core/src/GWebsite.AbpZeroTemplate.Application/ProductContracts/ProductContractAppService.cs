using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ProductContracts;
using GWebsite.AbpZeroTemplate.Application.Share.ProductContracts.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ProductContracts
{
    public class ProductContractAppService : GWebsiteAppServiceBase, IProductContractAppService
    {
        private readonly IRepository<ProductContract> productContractRepository;

        public ProductContractAppService(IRepository<ProductContract> productContractRepository)
        {
            this.productContractRepository = productContractRepository;
        }

        #region Public Method

        public void CreateOrEditProductContract(ProductContractInput ProductContractInput)
        {

            if (ProductContractInput.Id == 0)
            {
                Create(ProductContractInput);
            }
            else
            {
                Update(ProductContractInput);
            }
        }

        public void DeleteProductContract(int id)
        {
            var ProductContractEntity = productContractRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
            if (ProductContractEntity != null)
            {
                //ProductContractEntity.IsDelete = true;
                productContractRepository.Delete(ProductContractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public void DeleteMultiProductContract(int contractId)
        {
            productContractRepository.DeleteAsync(x => x.ContractId == contractId);
        }

        public ProductContractInput GetProductContractForEdit(int id)
        {
            var ProductContractEntity = productContractRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
            if (ProductContractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductContractInput>(ProductContractEntity);
        }

        public ProductContractForViewDto GetProductContractForView(int id)
        {
            try
            {
                var ProductContractEntity = productContractRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
                if (ProductContractEntity == null)
                {
                    Console.WriteLine("ProductContract with id=" + id.ToString() + " is null");
                    return null;
                }
                return ObjectMapper.Map<ProductContractForViewDto>(ProductContractEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception ProductContract for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<ProductContractDto> GetProductContracts(ProductContractFilter input)
        {
            Console.WriteLine("Contract Id Recieved: " + input.ContractId.ToString());
            var query = productContractRepository.GetAll()/*.Where(x => !x.IsDelete);*/;

            // filter by value

            query = query.Where(x => x.ContractId == input.ContractId);

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ProductContractDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductContractDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductContract_Create)]
        private void Create(ProductContractInput productContractInput)
        {
            try
            {
                var productContractEntity = ObjectMapper.Map<ProductContract>(productContractInput);
                if (productContractEntity == null) System.Console.WriteLine("null: ");
                //SetAuditInsert(ProductContractEntity);
                //var contractId = productContractRepository.InsertAndGetId(productContractEntity);
                //foreach (var productItem in productContractInput.Products)
                //{
                //    // insert

                //}
                //var sumProduct = productContractInput.Products.Sum(x => x.Quantity);
                // var contract = productContractRepository.Get(productContractEntity);
                //   productContractRepository.Update(productContractEntity);
                productContractRepository.Insert(productContractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductContract_Edit)]
        private void Update(ProductContractInput ProductContractInput)
        {
            var ProductContractEntity = productContractRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == ProductContractInput.Id);
            if (ProductContractEntity == null)
            {
            }
            ObjectMapper.Map(ProductContractInput, ProductContractEntity);
            //SetAuditEdit(ProductContractEntity);
            productContractRepository.Update(ProductContractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
