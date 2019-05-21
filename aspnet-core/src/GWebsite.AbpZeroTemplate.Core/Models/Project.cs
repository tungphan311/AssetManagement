using System;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Project : FullAuditModel
    {
        public string ProjectID { get; set; }

        public string Name { get; set; }

        public DateTime DayCreate { get; set; }

        public bool IsActive { get; set; }
    }
}