using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs.Dto
{
    /// <summary>
    /// <model cref="VehicleRepair"></model>
    /// </summary>
    public class VehicleRepairFilter : PagedAndSortedInputDto
    {
        public string AssetId { get; set; }
    }
}