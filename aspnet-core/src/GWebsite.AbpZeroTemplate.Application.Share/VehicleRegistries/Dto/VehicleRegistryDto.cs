using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries.Dto
{/// <summary>
 /// <model cref="VehicleRegistry"></model>
 /// </summary>
    public class VehicleRegistryDto : Entity<int>
    {
        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; } = System.DateTime.Now;
        public System.DateTime ExpirationDate { get; set; }
        public int RegisterNumber { get; set; }
        public int RegisterDuration { get; set; }
        public string RegisterUnit { get; set; }
        public string Note { get; set; }
    }
}
