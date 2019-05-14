using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductCategories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductDetails.Dto;
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

            // ProductCategory
            configuration.CreateMap<ProductCategory, ProductCategoryDto>();
            configuration.CreateMap<ProductCategoryInput, ProductCategory>();
            configuration.CreateMap<ProductCategory, ProductCategoryInput>();
            configuration.CreateMap<ProductCategory, ProductCategoryForViewDto>();

            // Provider
            configuration.CreateMap<Provider, ProviderDto>();
            configuration.CreateMap<ProductInput, Provider>();
            configuration.CreateMap<Provider, ProviderInput>();
            configuration.CreateMap<Provider, ProviderForViewDto>();

            //ProductDetail
            configuration.CreateMap<ProductDetail, ProductDetailDto>();
            configuration.CreateMap<ProductDetailInput, ProductDetail>();
            configuration.CreateMap<ProductDetail, ProductDetailInput>();

            // Project
            configuration.CreateMap<Project, ProjectDto>();
            configuration.CreateMap<ProjectInput, Project>();
            configuration.CreateMap<Project, ProjectInput>();
            configuration.CreateMap<Project, ProjectForViewDto>();
        }
    }
}