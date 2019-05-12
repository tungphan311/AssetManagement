using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductDetails.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.ProductDetail"></model>
    /// </summary>
    public class ProductDetailInput : Entity<int>
    {
        public int ProductCategoryId { get; set; }
        public int ProviderId { get; set; }
    }
}
