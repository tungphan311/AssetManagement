using Abp.Domain.Entities;
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
    public class Provider : FullAuditModel
    {
        public Provider()
        {

        }
        [Column(TypeName = "varchar(50)")]
        public string ProviderCode { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(500)]
        public string WebsiteUrl { get; set; }
        [StringLength(500)]
        public string Info { get; set; }
        public string Image { get; set; }
        public Status Status { get; set; }

        public string BlankField { get; set; }
        public string BlankField1 { get; set; }
        public string BlankField2 { get; set; }
        public string BlankField3 { get; set; }
    }
}
