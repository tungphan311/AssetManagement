using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ProductProvider : Entity<int>
    {
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public bool IsDelete { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }
    }
}
