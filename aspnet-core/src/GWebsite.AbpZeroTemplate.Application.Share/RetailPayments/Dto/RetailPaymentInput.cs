using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RetailPayments.Dto
{
    public class RetailPaymentInput: Entity<int>
    {
        public int RetailId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
