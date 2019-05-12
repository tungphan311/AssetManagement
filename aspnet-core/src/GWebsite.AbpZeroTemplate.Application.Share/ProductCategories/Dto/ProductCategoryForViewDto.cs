using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductCategories.Dto
{
    public class ProductCategoryForViewDto
    {
        public string Name { get; set; }
        public decimal ProductCategoryCode { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
