using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleModels.Dto
{
    /// <summary>
    /// <model cref="VehicleModel"></model>
    /// </summary>
    public class VehicleModelInput : Entity<int>
    {
        public string Model { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string TireSize { get; set; }
        public string FuelType { get; set; }
        public string EngineType { get; set; }
        public string GearboxType { get; set; }
        public float FuelNorms { get; set; }
        public float EngineVolume { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public float HorizontalLength { get; set; }
    }
}