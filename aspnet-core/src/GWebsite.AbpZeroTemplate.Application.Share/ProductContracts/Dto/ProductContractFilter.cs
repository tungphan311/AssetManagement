using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductContracts.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.ProductContract"></model>
    /// </summary>
    public class ProductContractFilter : PagedAndSortedInputDto
    {
        public int ContractId { get; set; }
    }
}
