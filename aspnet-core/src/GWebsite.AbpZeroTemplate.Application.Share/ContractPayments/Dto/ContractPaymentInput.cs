using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto
{
    /// <summary>
    /// <model cref="ContractPayment"></model>
    /// </summary>
    public class ContractPaymentInput : Entity<int>
    {
        public int ContractID { get; set; }
        public int Batch { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Percent { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
    }
}
