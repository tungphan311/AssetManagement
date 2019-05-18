using System;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ContractPayment : FullAuditModel
    {
        public int ContractID { get; set; }
        public int Batch { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Percent { get; set; }
        public float Amount { get; set; }
    }
}