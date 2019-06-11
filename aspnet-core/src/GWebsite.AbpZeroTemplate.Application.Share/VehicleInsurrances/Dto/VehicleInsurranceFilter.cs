using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances.Dto
{
    /// <summary>
    /// <model cref="VehicleInsurrance"></model>
    /// </summary>
    public class VehicleInsurranceFilter : PagedAndSortedInputDto
    {
        public string PlateNumber { get; set; }
    }
}
