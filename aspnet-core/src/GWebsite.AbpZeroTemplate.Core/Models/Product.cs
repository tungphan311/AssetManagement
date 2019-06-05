using GWebsite.AbpZeroTemplate.Core.Models.Enums.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Product : FullAuditModel
    {
        public Product()
        {
            ExpectedPrice = 0;
            CurrentPrice = 0;
            VAT = 0;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsDelete = false;
        }
        [Column(TypeName = "varchar(50)")]
        public string ProductCode { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(500)]
        public string ProductName { get; set; }
        [DefaultValue(0)]
        public decimal ExpectedPrice { get; set; }
        [DefaultValue(0)]
        public decimal CurrentPrice { get; set; }
        [DefaultValue(0)]
        public decimal VAT { get; set; }
        public string Image { get; set; }
        [StringLength(500)]
        public string Url { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }

    }
}
