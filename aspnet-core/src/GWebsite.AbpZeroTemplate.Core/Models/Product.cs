using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Product : FullAuditModel
    {
        //public int ProviderId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }
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
