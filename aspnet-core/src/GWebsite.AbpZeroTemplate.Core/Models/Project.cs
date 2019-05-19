namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Project : FullAuditModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}