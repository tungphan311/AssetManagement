using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.ContractPaymentDetail"></model>
    /// </summary>
    public class ContractPaymentDetailFilter : PagedAndSortedInputDto
    {
        public int ContractId { get; set; }
    }
}
