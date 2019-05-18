using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto
{
    /// <summary>
    /// <model cref="ContractPayment"></model>
    /// </summary>
    public class ContractPaymentFilter : PagedAndSortedInputDto
    {
        public int ContractID { get; set; }     
    }
}
