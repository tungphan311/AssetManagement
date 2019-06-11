using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto
{
    /// <summary>
    /// <model cref="Vehicle"></model>
    /// </summary>
    public class VehicleDto : Entity<int>
    {
        public string AssetId { get; set; }
        public string PlateNumber { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string UnitUsed { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public bool SpecialVehicle { get; set; }
    }
}