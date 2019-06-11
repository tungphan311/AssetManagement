using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances.Dto
{
    /// <summary>
    /// <model cref="VehicleMaintenance"></model>
    /// </summary>
    public class VehicleMaintenanceFilter : PagedAndSortedInputDto
    {
        public string PlateNumber { get; set; }
    }
}