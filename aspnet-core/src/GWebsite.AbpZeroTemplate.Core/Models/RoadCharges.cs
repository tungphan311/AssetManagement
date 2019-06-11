namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class RoadCharges : FullAuditModel
    {
        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; } = System.DateTime.Now;
        public string Type { get; set; }
        public System.DateTime ExpirationDate { get; set; } = System.DateTime.Now;
        public float MoneyAmount { get; set; }
        public string FeeUnit { get; set; }
        public string Note { get; set; }
    }
}