using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations.Dto
{
    /// <summary>
    /// <model cref="VehicleOperation"></model>
    /// </summary>
    public class VehicleOperationFilter : PagedAndSortedInputDto
    {
        public string PlateNumber { get; set; }
    }
}