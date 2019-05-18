using Abp.Domain.Entities;
using System;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto
{
    /// <summary>
    /// <model cref="ContractPayment"></model>
    /// </summary>
    public class ContractPaymentDto : Entity<int>
    {
        public int ContractID { get; set; }
        public int Batch { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Percent { get; set; }
        public float Amount { get; set; }
    }
}
