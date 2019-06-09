using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class PurchasePaymentHistory : FullAuditModel
    {

        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentMoney { get; set; }
        public decimal? PaidMoney { get; set; }

        //FK
        public int PurchaseOrderId { get; set; }
    }
}
