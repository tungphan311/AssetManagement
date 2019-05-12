using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductCategories.Dto
{
    public class ProductCategoryFilter : PagedAndSortedInputDto
    {
        /// <summary>
        /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.ProductCategory"></model>
        /// </summary>
        public string Name { get; set; }
    }
}
