using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandise.Dto
{
    public class MerchandiseDto: Entity<int>
    {
        public string Name { get; set; }
        public int TypeID { get; set; }
        public string Info { get; set; }
        public double Price { get; set; }
    }
}
