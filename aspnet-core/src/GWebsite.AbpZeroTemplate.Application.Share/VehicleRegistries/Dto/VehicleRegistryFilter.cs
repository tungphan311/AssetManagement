using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries.Dto
{
    /// <summary>
    /// <model cref="VehicleRegistry"></model>
    /// </summary>
    public class VehicleRegistryFilter : PagedAndSortedInputDto
    {
        public string PlateNumber { get; set; }
    }
}
