using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto
{
    /// <summary>
    /// <model cref="Customer"></model>
    /// </summary>
    public class ContractFilter : PagedAndSortedInputDto
    {
        [Required]
        public virtual int ContractID { get; set; }

        [Required]
        public virtual string Name { get; set; }

    }
        
}
