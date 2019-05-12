using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductCategories.Dto
{
    public class ProductCategoryInput : Entity<int>
    {
        /// <summary>
        /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.ProductCategory"></model>
        /// </summary>
        public string Name { get; set; }
        public decimal ProductCategoryCode { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
