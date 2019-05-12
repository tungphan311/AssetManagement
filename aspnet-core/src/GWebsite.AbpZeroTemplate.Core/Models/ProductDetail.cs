using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ProductDetail : Entity<int>
    {
        public int ProductCategoryId { get; set; }
        public int ProviderId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }
    }
}
