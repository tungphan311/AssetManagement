using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RoadCharges.Dto
{
    /// <summary>
    /// <model cref="RoadCharges"></model>
    /// </summary>
    public class RoadChargesFilter : PagedAndSortedInputDto
    {
        public string PlateNumber { get; set; }
    }
}