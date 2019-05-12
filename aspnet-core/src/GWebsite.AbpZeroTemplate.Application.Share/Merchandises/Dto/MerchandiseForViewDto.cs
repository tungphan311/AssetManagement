using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandises.Dto
{
    public class MerchandiseForViewDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int TypeID { get; set; }

        public int TypeVender { get; set; }

        public string Price { get; set; }

        public string Unit { get; set; }

        public string Info { get; set; }

        public bool IsActive { get; set; }

        public string Note { get; set; }
    }
}
