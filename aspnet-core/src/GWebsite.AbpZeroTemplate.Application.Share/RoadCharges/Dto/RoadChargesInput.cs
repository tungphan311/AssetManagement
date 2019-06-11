using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RoadCharges.Dto
{
    /// <summary>
    /// <model cref="RoadCharges"></model>
    /// </summary>
    public class RoadChargesInput : Entity<int>
    {
        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; }
        public string Type { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public float MoneyAmount { get; set; }
        public string FeeUnit { get; set; }
        public string Note { get; set; }
    }
}