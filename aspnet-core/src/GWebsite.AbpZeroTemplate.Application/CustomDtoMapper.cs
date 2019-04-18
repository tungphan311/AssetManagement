using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetRents.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.AssetsRents.Dto;

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

            //Asset 
            configuration.CreateMap<Asset, AssetDto>();
            configuration.CreateMap<Asset, AssetFilter>();
            configuration.CreateMap<Asset, AssetForView>();
            configuration.CreateMap<Asset, AssetInput>();
            configuration.CreateMap<AssetInput, Asset>();
           
            //AssetRent 
            configuration.CreateMap<AsssetRent, AssetRentDto>();
            configuration.CreateMap<AsssetRent, AssetRentFilter>();
            configuration.CreateMap<AsssetRent, AssetRentForView>();
            configuration.CreateMap<AsssetRent, AssetRentInput>();
            configuration.CreateMap<AssetRentInput, AsssetRent>();

        }
    }
}