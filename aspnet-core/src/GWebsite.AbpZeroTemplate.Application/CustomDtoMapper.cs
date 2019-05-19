using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductProviders.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;
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
        }
    }
}