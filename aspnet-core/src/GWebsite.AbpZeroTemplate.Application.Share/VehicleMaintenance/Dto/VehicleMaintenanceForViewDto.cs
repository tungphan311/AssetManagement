using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances.Dto
{
    /// <summary>
    /// <model cref="VehicleMaintenance"></model>
    /// </summary>
    public class VehicleMaintenanceForViewDto
    {
        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime NextMaintenanceDate { get; set; }
        public int MoneyAmount { get; set; }
        public int NumberMaintenanceTimes { get; set; }
        public string MaintenanceCategories { get; set; }
        public string Note { get; set; }
        public string MaintenanceUnit { get; set; }

    }
}