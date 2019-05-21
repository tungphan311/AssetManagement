using System;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Project : FullAuditModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}