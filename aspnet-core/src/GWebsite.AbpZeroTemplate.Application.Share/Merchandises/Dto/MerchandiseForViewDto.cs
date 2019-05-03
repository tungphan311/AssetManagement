using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandises.Dto
{
    public class MerchandiseForViewDto
    {
        public string Name { get; set; }

        public int TypeID { get; set; }

        public string Info { get; set; }

        public double Price { get; set; }
    }
}
