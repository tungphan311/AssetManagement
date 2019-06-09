using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PurchasePaymentHistories.Dto
{
    public class PurchasePaymentHistoryDto : Entity<int>
    {
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentMoney { get; set; }
        public decimal? PaidMoney { get; set; }

        //FK
        public int PurchaseOrderId { get; set; }
    }
}
