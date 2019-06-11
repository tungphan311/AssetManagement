using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.POPayments.Dto
{
    /// <summary>
    /// <model cref="POPayment"></model>
    /// </summary>
    public class POPaymentFilter : PagedAndSortedInputDto
    {
        public int POID { get; set; }     
    }
}
