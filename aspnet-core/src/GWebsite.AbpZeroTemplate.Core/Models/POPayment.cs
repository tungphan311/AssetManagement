using System;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class POPayment : FullAuditModel
    {
        public int POID { get; set; }
        public int Batch { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Percent { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
    }
}