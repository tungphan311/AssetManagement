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
            Price = 0;
            WholePrice = 0;
            VAT = 0;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsDelete = true;
        }
        //public int ProviderId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [DefaultValue(0)]
        public decimal Price { get; set; }
        [DefaultValue(0)]
        public decimal VAT { get; set; }
        [DefaultValue(0)]
        public decimal WholePrice { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(500)]
        public string Url { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Alias { get; set; }
        //[ForeignKey("ProviderId")]
        //public virtual Provider Provider { get; set; }
    }
}
