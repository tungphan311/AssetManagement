using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Products.Dto
{
    /// <summary>
    /// <model cref="Product"></model>
    /// </summary>
    public class ProductFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
