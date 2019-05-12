using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.MerchandiseTypes.Dto
{
    public class MerchandiseTypeDto: Entity<int>
    {
        public string TypeID { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public string Note { get; set; }
    }
}
