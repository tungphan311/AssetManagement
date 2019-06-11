using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.POMerchandises.Dto
{
    public class POMerchandiseInput: Entity<int>
    {
        public int VendorID { get; set; }

        public int ProjectID { get; set; }

        public int MerchandiseID { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public int VAT { get; set; }

        public double TotalPrice { get; set; }
    }
}
