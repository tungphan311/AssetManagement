using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RoadCharges.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleModels.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

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

            configuration.CreateMap<string, DateTime?>()
                .ConvertUsing(x => DateTime.ParseExact(x, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture));

            configuration.CreateMap<DateTime?, string>()
                .ConvertUsing(x => x?.ToString("dd/MM/yyyy"));

            // Vehicle
            configuration.CreateMap<Vehicle, VehicleDto>();
            configuration.CreateMap<VehicleInput, Vehicle>();
            configuration.CreateMap<Vehicle, VehicleInput>();
            configuration.CreateMap<Vehicle, VehicleForViewDto>();

            // Asset
            configuration.CreateMap<Asset, AssetDto>();
            configuration.CreateMap<AssetInput, Asset>();
            configuration.CreateMap<Asset, AssetInput>();
            configuration.CreateMap<Asset, AssetForViewDto>();

            // Attached Device
            configuration.CreateMap<AttachedDevice, AttachedDeviceDto>();
            configuration.CreateMap<AttachedDeviceInput, AttachedDevice>();
            configuration.CreateMap<AttachedDevice, AttachedDeviceInput>();
            configuration.CreateMap<AttachedDevice, AttachedDeviceForViewDto>();

            // Vehicle Opeartion
            configuration.CreateMap<VehicleOperation, VehicleOperationDto>();
            configuration.CreateMap<VehicleOperationInput, VehicleOperation>();
            configuration.CreateMap<VehicleOperation, VehicleOperationInput>();
            configuration.CreateMap<VehicleOperation, VehicleOperationForViewDto>();

            // Road Charges
            configuration.CreateMap<RoadCharges, RoadChargesDto>();
            configuration.CreateMap<RoadChargesInput, RoadCharges>();
            configuration.CreateMap<RoadCharges, RoadChargesInput>();
            configuration.CreateMap<RoadCharges, RoadChargesForViewDto>();

            // Vehicle Registry
            configuration.CreateMap<VehicleRegistry, VehicleRegistryDto>();
            configuration.CreateMap<VehicleRegistryInput, VehicleRegistry>();
            configuration.CreateMap<VehicleRegistry, VehicleRegistryInput>();
            configuration.CreateMap<VehicleRegistry, VehicleRegistryForViewDto>();

            // Vehicle Insurrance
            configuration.CreateMap<VehicleInsurrance, VehicleInsurranceDto>();
            configuration.CreateMap<VehicleInsurranceInput, VehicleInsurrance>();
            configuration.CreateMap<VehicleInsurrance, VehicleInsurranceInput>();
            configuration.CreateMap<VehicleInsurrance, VehicleInsurranceForViewDto>();

            // Vehicle Maintanence
            configuration.CreateMap<VehicleMaintenance, VehicleMaintenanceDto>();
            configuration.CreateMap<VehicleMaintenanceInput, VehicleMaintenance>();
            configuration.CreateMap<VehicleMaintenance, VehicleMaintenanceInput>();
            configuration.CreateMap<VehicleMaintenance, VehicleMaintenanceForViewDto>();

            // Vehicle Repair
            configuration.CreateMap<VehicleRepair, VehicleRepairDto>();
            configuration.CreateMap<VehicleRepairInput, VehicleRepair>();
            configuration.CreateMap<VehicleRepair, VehicleRepairInput>();
            configuration.CreateMap<VehicleRepair, VehicleRepairForViewDto>();

            // Vehicle Model
            configuration.CreateMap<VehicleModel, VehicleModelDto>();
            configuration.CreateMap<VehicleModelInput, VehicleModel>();
            configuration.CreateMap<VehicleModel, VehicleModelInput>();
            configuration.CreateMap<VehicleModel, VehicleModelForViewDto>();
        }
    }
}