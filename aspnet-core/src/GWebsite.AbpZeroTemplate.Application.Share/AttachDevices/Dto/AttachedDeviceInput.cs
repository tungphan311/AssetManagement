using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices.Dto
{
    /// <summary>
    /// <model cref="AttachedDevice"></model>
    /// </summary>
    public class AttachedDeviceInput : Entity<int>
    {
        public string PlateNumber { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Explain { get; set; }
    }
}