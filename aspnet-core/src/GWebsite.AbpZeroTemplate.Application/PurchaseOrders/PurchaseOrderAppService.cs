using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasePaymentHistories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseProductDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.PurchaseOrders
{
    public class PurchaseOrderAppService : GWebsiteAppServiceBase, Application.Share.PurchaseOrders.IPurchaseOrderAppService
    {
        private readonly IRepository<PurchaseOrder> purchaseOrderRepository;
        private readonly IRepository<PurchasePaymentHistory> paymentRepository;
        private readonly IRepository<PurchaseProductDetail> purchaseProductDetailRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Provider> providerRepository;
        private readonly IRepository<Contract> contractRepository;

        public PurchaseOrderAppService(IRepository<PurchaseOrder> purchaseOrderRepository,
            IRepository<PurchaseProductDetail> purchaseProductDetailRepository,
            IRepository<Product> productRepository, IRepository<PurchasePaymentHistory> paymentRepository,
            IRepository<Provider> providerRepository, IRepository<Contract> contractRepository)
        {
            this.purchaseOrderRepository = purchaseOrderRepository;
            this.paymentRepository = paymentRepository;
            this.purchaseProductDetailRepository = purchaseProductDetailRepository;
            this.productRepository = productRepository;
            this.providerRepository = providerRepository;
            this.contractRepository = contractRepository;
        }

        #region Public Method

        public void CreateOrEditPurchaseOrder(PurchaseOrderInput PurchaseOrderInput)
        {
            if (PurchaseOrderInput.UnitId != null && PurchaseOrderInput.UnitId == 0)
            {
                PurchaseOrderInput.UnitId = null;
            }
            if (PurchaseOrderInput.ContractId != null && PurchaseOrderInput.ContractId == 0)
            {
                PurchaseOrderInput.ContractId = null;
            }
            if (PurchaseOrderInput.ProviderId != null && PurchaseOrderInput.ProviderId == 0)
            {
                PurchaseOrderInput.ProviderId = null;
            }

            if (PurchaseOrderInput.Id == 0)
            {
                Create(PurchaseOrderInput);
            }
            else
            {
                Update(PurchaseOrderInput);
            }
        }

        public void DeletePurchaseOrder(int id)
        {
            var purchaseOrderEntity = purchaseOrderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (purchaseOrderEntity != null)
            {
                purchaseOrderEntity.IsDelete = true;
                purchaseOrderRepository.Update(purchaseOrderEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public PurchaseOrderInput GetPurchaseOrderForEdit(int id)
        {
            var purchaseOrderEntity = purchaseOrderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (purchaseOrderEntity == null)
            {
                return null;
            }




            var purchaseOrderInput = ObjectMapper.Map<PurchaseOrderInput>(purchaseOrderEntity);

            var purchaseProductDetails = ObjectMapper.Map<List<PurchaseProductDetailInput>>(purchaseProductDetailRepository.GetAll().Where(x => x.PurchaseOrderId == purchaseOrderEntity.Id /*&& x.IsDelete == false*/).ToList());
            if (purchaseProductDetails != null && purchaseProductDetails.Count() > 0)
            {
                for (int i = 0; i < purchaseProductDetails.Count(); i++)
                {
                    var prod = ObjectMapper.Map<ProductInput>(productRepository.FirstOrDefault(x => x.Id == purchaseProductDetails.ElementAt(i).ProductId && x.IsDelete == false));
                    if (prod == null) prod = new ProductInput();
                    purchaseProductDetails.ElementAt(i).Product = prod;
                }
            }


            if (purchaseOrderInput.ContractId != null)
            {
                purchaseOrderInput.Contract = ObjectMapper.Map<ContractInput>(contractRepository.GetAll().Where(X => X.IsDelete == false).FirstOrDefault(x => x.Id == purchaseOrderInput.ContractId));
            }


            if (purchaseOrderInput.ProviderId != null)
            {
                purchaseOrderInput.Provider = ObjectMapper.Map<ProviderInput>(providerRepository.GetAll().Where(X => X.IsDelete == false).FirstOrDefault(x => x.Id == purchaseOrderInput.ProviderId));
            }



            if (purchaseProductDetails == null) purchaseProductDetails = new List<PurchaseProductDetailInput>();
            purchaseOrderInput.PurchaseProductDetails = (purchaseProductDetails);


            var payments = ObjectMapper.Map<List<PurchasePaymentHistoryInput>>(paymentRepository.GetAll().Where(x => x.PurchaseOrderId == purchaseOrderEntity.Id && x.IsDelete == false).ToList());
            purchaseOrderInput.PurchasePaymentHistories = (payments);

            return (purchaseOrderInput);
        }

        public PurchaseOrderForViewDto GetPurchaseOrderForView(int id)
        {
            try
            {
                var purchaseOrderEntity = purchaseOrderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
                if (purchaseOrderEntity == null)
                {
                    Console.WriteLine("PurchaseOrder with id=" + id.ToString() + " is null");
                    return null;
                }
                var purchaseProductDetails = ObjectMapper.Map<List<PurchaseProductDetailInput>>(purchaseProductDetailRepository.GetAll().Where(x => x.ContractId == purchaseOrderEntity.Id /*&& x.IsDelete == false*/).ToList());
                if (purchaseProductDetails.Count() > 0)
                {
                    for (int i = 0; i < purchaseProductDetails.Count(); i++)
                    {
                        var prod = ObjectMapper.Map<ProductInput>(productRepository.FirstOrDefault(x => x.Id == purchaseProductDetails.ElementAt(i).ProductId && x.IsDelete == false));
                        if (prod == null) prod = new ProductInput();
                        purchaseProductDetails.ElementAt(i).Product = prod;
                    }
                }
                return ObjectMapper.Map<PurchaseOrderForViewDto>(purchaseOrderEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception PurchaseOrder for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<PurchaseOrderDto> GetPurchaseOrders(PurchaseOrderFilter input)
        {
            var query = purchaseOrderRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(input.Name));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<PurchaseOrderDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PurchaseOrderDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_PurchaseOrder_Create)]
        private void Create(PurchaseOrderInput purchaseOrderInput)
        {
            System.Console.WriteLine("PurchaseOrderInput: " + purchaseOrderInput.ToString());
            try
            {
                var purchaseOrderEntity = ObjectMapper.Map<PurchaseOrder>(purchaseOrderInput);
                if (purchaseOrderEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(purchaseOrderEntity);

                var purchaseOrderId = purchaseOrderRepository.InsertAndGetId(purchaseOrderEntity);

                if (purchaseOrderInput.PurchaseProductDetails != null && purchaseOrderInput.PurchaseProductDetails.Count() > 0)
                {

                    foreach (var item in purchaseOrderInput.PurchaseProductDetails)
                    {
                        if (item.ContractId == 0) item.ContractId = null;
                        if (item.ProjectId == 0) item.ProjectId = null;
                        if (item.UnitId == 0) item.UnitId = null;

                        item.PurchaseOrderId = purchaseOrderId;
                        var purchaseProductItem = ObjectMapper.Map<PurchaseProductDetail>(item);

                        purchaseProductDetailRepository.Insert(purchaseProductItem);
                    }

                }

                if (purchaseOrderInput.PurchasePaymentHistories != null && purchaseOrderInput.PurchasePaymentHistories.Count() > 0)
                {
                    foreach (var item in purchaseOrderInput.PurchasePaymentHistories)
                    {

                        var paymentItem = ObjectMapper.Map<PurchasePaymentHistory>(item);
                        paymentItem.PurchaseOrderId = purchaseOrderId;
                        //paymentItem.PurchaseOrderId = purchaseOrderId;
                        //paymentItem.PaymentDate = item.PaymentDate;
                        //paymentItem.PaymentMoney = item.PaymentMoney;
                        //paymentItem.PaidMoney = item.PaidMoney;
                        SetAuditInsert(paymentItem);

                        paymentRepository.Insert(paymentItem);
                    }
                }

                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_PurchaseOrder_Edit)]
        private void Update(PurchaseOrderInput purchaseOrderInput)
        {
            var purchaseOrderEntity = purchaseOrderRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == purchaseOrderInput.Id);
            if (purchaseOrderEntity == null)
            {
            }
            ObjectMapper.Map(purchaseOrderInput, purchaseOrderEntity);
            SetAuditEdit(purchaseOrderEntity);

            //
            var PurchaseOrderId = purchaseOrderEntity.Id;

            purchaseProductDetailRepository.Delete(x => x.PurchaseOrderId == PurchaseOrderId);

            if (purchaseOrderInput.PurchaseProductDetails != null && purchaseOrderInput.PurchaseProductDetails.Count() > 0)
            {

                foreach (var item in purchaseOrderInput.PurchaseProductDetails)
                {
                    if (item.ContractId == 0) item.ContractId = null;
                    if (item.ProjectId == 0) item.ProjectId = null;
                    if (item.UnitId == 0) item.UnitId = null;
                    item.PurchaseOrderId = purchaseOrderInput.Id;
                    var purchaseProductItem = ObjectMapper.Map<PurchaseProductDetail>(item);

                    purchaseProductDetailRepository.Insert(purchaseProductItem);
                }

            }

            paymentRepository.Delete(x => x.PurchaseOrderId == PurchaseOrderId);
            if (purchaseOrderInput.PurchasePaymentHistories != null && purchaseOrderInput.PurchasePaymentHistories.Count() > 0)
            {
                foreach (var item in purchaseOrderInput.PurchasePaymentHistories)
                {
                    var paymentItem = ObjectMapper.Map<PurchasePaymentHistory>(item);
                    paymentItem.PurchaseOrderId = PurchaseOrderId;
                    //paymentItem.PaymentDate = item.PaymentDate;
                    //paymentItem.PaymentMoney = item.PaymentMoney;
                    //paymentItem.PaidMoney = item.PaidMoney;
                    SetAuditInsert(paymentItem);

                    paymentRepository.Insert(paymentItem);
                }
            }

            purchaseOrderRepository.Update(purchaseOrderEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}




