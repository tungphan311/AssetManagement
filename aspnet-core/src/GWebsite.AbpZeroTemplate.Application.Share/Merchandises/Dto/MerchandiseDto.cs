using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandises.Dto
{
    public class MerchandiseDto: Entity<int>
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

        public bool IsAddContract { get; set; }
    }
}
