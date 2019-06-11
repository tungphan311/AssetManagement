using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleModels.Dto
{
    /// <summary>
    /// <model cref="VehicleModel"></model>
    /// </summary>
    public class VehicleModelFilter : PagedAndSortedInputDto
    {
        public string Model { get; set; }
    }
}