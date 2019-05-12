using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Application.Share.ProductDetails.Dto;
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
    public class ProductInput : Entity<int>
    {
        public string Name { get; set; }
        public decimal ExpectedPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int ProductDetailId { get; set; }
        public ProductDetailInput ProductDetail { get; set; }
    }
}
