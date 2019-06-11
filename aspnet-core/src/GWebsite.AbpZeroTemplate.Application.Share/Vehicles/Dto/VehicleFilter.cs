using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto
{
    /// <summary>
    /// <model cref="Vehicle"></model>
    /// </summary>
    public class VehicleFilter : PagedAndSortedInputDto
    {
        public string PlateNumber { get; set; }
    }
}