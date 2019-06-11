using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.RetailPayments.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Retails.Dto
{
    public class RetailInput : Entity<int>
    {
        public string Code { get; set; }
        public int MerchandiseID { get; set; }
        public int VendorID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int BoughtQuantity { get; set; }
        public double Total { get; set; }

        public List<RetailPaymentInput> Payments { get; set; }
    }
}
