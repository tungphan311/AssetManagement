using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances.Dto
{
    /// <summary>
    /// <model cref="VehicleInsurrance"></model>
    /// </summary>
   public class VehicleInsurranceDto : Entity<int>
    {

        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; } = System.DateTime.Now;
        public System.DateTime ExpirationDate { get; set; }
        public string Type { get; set; }
        public int InsurranceNumber { get; set; }
        public int InsurranceDuration { get; set; }
        public string InsurranceUnit { get; set; }
        public int MoneyAmount { get; set; }
    }
}
