using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductContracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductProviders.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasePaymentHistories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseProductDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Applications
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<MenuClient, MenuClientDto>();
            configuration.CreateMap<MenuClient, MenuClientListDto>();
            configuration.CreateMap<CreateMenuClientInput, MenuClient>();
            configuration.CreateMap<UpdateMenuClientInput, MenuClient>();

            // DemoModel
            configuration.CreateMap<DemoModel, DemoModelDto>();
            configuration.CreateMap<DemoModelInput, DemoModel>();
            configuration.CreateMap<DemoModel, DemoModelInput>();
            configuration.CreateMap<DemoModel, DemoModelForViewDto>();

            // Customer
            configuration.CreateMap<Customer, CustomerDto>();
            configuration.CreateMap<CustomerInput, Customer>();
            configuration.CreateMap<Customer, CustomerInput>();
            configuration.CreateMap<Customer, CustomerForViewDto>();

            // Product
            configuration.CreateMap<Product, ProductDto>();
            configuration.CreateMap<ProductDto, Product>();
            configuration.CreateMap<ProductInput, Product>();
            configuration.CreateMap<Product, ProductInput>();
            configuration.CreateMap<Product, ProductForViewDto>();
            // Provider
            configuration.CreateMap<Provider, ProviderDto>();
            configuration.CreateMap<ProviderInput, Provider>();
            configuration.CreateMap<Provider, ProviderInput>();
            configuration.CreateMap<Provider, ProviderForViewDto>();

            //ProductProvider
            configuration.CreateMap<ProductProvider, ProductProviderDto>();
            configuration.CreateMap<ProductProviderInput, ProductProvider>();
            configuration.CreateMap<ProductProvider, ProductProviderInput>();

            // Project
            configuration.CreateMap<Project, ProjectDto>();
            configuration.CreateMap<ProjectInput, Project>();
            configuration.CreateMap<Project, ProjectInput>();
            configuration.CreateMap<Project, ProjectForViewDto>();

            // Bid
            configuration.CreateMap<Bid, BidDto>();
            configuration.CreateMap<BidInput, Bid>();
            configuration.CreateMap<Bid, BidInput>();
            configuration.CreateMap<Bid, BidForViewDto>();

            // BidDetail
            configuration.CreateMap<BidDetail, BidDetailDto>();
            configuration.CreateMap<BidDetailInput, BidDetail>();
            configuration.CreateMap<BidDetail, BidDetailInput>();
            configuration.CreateMap<BidDetail, BidDetailForViewDto>();

            // Contract
            configuration.CreateMap<Contract, ContractDto>();
            configuration.CreateMap<ContractInput, Contract>();
            configuration.CreateMap<Contract, ContractInput>();
            configuration.CreateMap<Contract, ContractForViewDto>();

            // ContractPaymentDetail
            configuration.CreateMap<ContractPaymentDetail, ContractPaymentDetailDto>();
            configuration.CreateMap<ContractPaymentDetailInput, ContractPaymentDetail>();
            configuration.CreateMap<ContractPaymentDetail, ContractPaymentDetailInput>();
            configuration.CreateMap<ContractPaymentDetail, ContractPaymentDetailForViewDto>();

            // ProductContract
            configuration.CreateMap<ProductContract, ProductContractDto>();
            configuration.CreateMap<ProductContractInput, ProductContract>();
            configuration.CreateMap<ProductContract, ProductContractInput>();
            configuration.CreateMap<ProductContract, ProductContractForViewDto>();

            // PurchaseOrder
            configuration.CreateMap<PurchaseOrder, PurchaseOrderDto>();
            configuration.CreateMap<PurchaseOrderInput, PurchaseOrder>();
            configuration.CreateMap<PurchaseOrder, PurchaseOrderInput>();
            configuration.CreateMap<PurchaseOrder, PurchaseOrderForViewDto>();

            // PurchasePaymentHistory
            configuration.CreateMap<PurchasePaymentHistory, PurchasePaymentHistoryDto>();
            configuration.CreateMap<PurchasePaymentHistoryInput, PurchasePaymentHistory>();
            configuration.CreateMap<PurchasePaymentHistory, PurchasePaymentHistoryInput>();

            // PurchaseProductDetail
            configuration.CreateMap<PurchaseProductDetail, PurchaseProductDetailDto>();
            configuration.CreateMap<PurchaseProductDetailInput, PurchaseProductDetail>();
            configuration.CreateMap<PurchaseProductDetail, PurchaseProductDetailInput>();
        }
    }
}