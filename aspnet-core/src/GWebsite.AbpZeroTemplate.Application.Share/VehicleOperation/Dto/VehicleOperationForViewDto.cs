using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations.Dto
{
    /// <summary>
    /// <model cref="VehicleOperation"></model>
    /// </summary>
    public class VehicleOperationForViewDto
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