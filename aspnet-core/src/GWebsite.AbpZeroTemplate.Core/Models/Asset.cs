namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset: FullAuditModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public float Cost { get; set; }
    }
}
