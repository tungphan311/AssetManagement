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
    public class ProductCategory : FullAuditModel
    {
        public string ProductCategoryCode { get; set; }
        //public int ProviderId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public Status Status { get; set; }
        //Blank Field
        public int BlankField0 { get; set; }
        public int BlankField1 { get; set; }
        public int BlankField2 { get; set; }
        public decimal BlankField3 { get; set; }
        public decimal BlankField4 { get; set; }
        public decimal BlankField5 { get; set; }
        public string BlankField6 { get; set; }
        public string BlankField7 { get; set; }
        public string BlankField8 { get; set; }
        public string BlankField9 { get; set; }
        public string BlankField10 { get; set; }
    }
}
