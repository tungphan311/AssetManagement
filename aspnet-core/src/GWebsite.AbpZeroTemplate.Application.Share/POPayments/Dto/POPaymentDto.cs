using Abp.Domain.Entities;
using System;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.POPayments.Dto
{
    /// <summary>
    /// <model cref="POPayment"></model>
    /// </summary>
    public class POPaymentDto : Entity<int>
    {
        public int POID { get; set; }
        public int Batch { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Percent { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
    }
}
