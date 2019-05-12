using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes.Dto
{
    public class MerchandiseTypeFilter: PagedAndSortedInputDto
    {
        public string TypeID { get; set; }

        public string Name { get; set; }

        public string IsActive { get; set; }
    }
}
