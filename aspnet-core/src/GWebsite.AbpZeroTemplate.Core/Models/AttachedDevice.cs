namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AttachedDevice: FullAuditModel
    {
        public string PlateNumber { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Explain { get; set; }
    }
}