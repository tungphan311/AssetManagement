using GWebsite.AbpZeroTemplate.Core.Models.Enums.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Project : FullAuditModel
    {
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }
        public string ActivityType { get; set; }
        public DateTime ProjectCreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
