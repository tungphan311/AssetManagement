using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices.Dto
{
    /// <summary>
    /// <model cref="AttachedDevice"></model>
    /// </summary>
    public class AttachedDeviceFilter : PagedAndSortedInputDto
    {
        public string PlateNumber { get; set; }
    }
}