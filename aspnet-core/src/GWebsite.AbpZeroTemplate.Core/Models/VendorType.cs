namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class VendorType : FullAuditModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}