using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Products.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.Product"></model>
    /// </summary>
    public class ProductDto : Entity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
