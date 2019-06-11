namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class VehicleOperation : FullAuditModel
    {
        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; }
        public int VehicleIndex { get; set; }
        public float KmGone { get; set; }
        public float FuelNorm { get; set; }
        public float RealConsumption { get; set; }
        public string Note { get; set; }
    }
}