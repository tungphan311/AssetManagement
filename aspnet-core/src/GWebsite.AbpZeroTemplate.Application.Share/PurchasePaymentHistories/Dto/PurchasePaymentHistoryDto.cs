using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PurchasePaymentHistories.Dto
{
    public class PurchasePaymentHistoryDto : Entity<int>
    {
        public int? InstallmentNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Percent { get; set; }
        public decimal? Price { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        //Adding Expected Field Expand
        [StringLength(500)]
        public string Note { get; set; }

        public decimal? PaymentMoney { get; set; }
        public decimal? PaidMoney { get; set; }

        //FK
        public int PurchaseOrderId { get; set; }
    }
}
