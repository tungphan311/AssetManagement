namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Vehicle : FullAuditModel
    {
        public string PlateNumber { get; set; }
        public string CountryOfManufacture { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
        public int YearOfManufacture { get; set; }
        public string Color { get; set; }
        public string UnitUsed { get; set; }
        public string OwnerName { get; set; }
        public string UsePurpose { get; set; }
        public System.DateTime RegistrationDate { get; set; } = System.DateTime.Now;
        public string EngineNumber { get; set; }
        public string RibNumber { get; set; }
        public string TireSize { get; set; }
        public string EngineType { get; set; }
        public string GearboxType { get; set; }
        public float FuelNorms { get; set; }
        public float EngineVolume { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public float HorizontalLength { get; set; }
        public bool SpecialVehicle { get; set; }
    }
}