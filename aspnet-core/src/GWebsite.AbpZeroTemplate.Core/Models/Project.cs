using GWebsite.AbpZeroTemplate.Core.Models.Enums.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Project : FullAuditModel
    {
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime ProjectCreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
