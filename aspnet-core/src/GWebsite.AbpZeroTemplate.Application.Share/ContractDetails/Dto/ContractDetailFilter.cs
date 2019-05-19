using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto
{
    /// <summary>
    /// <model cref="ContractDetail"></model>
    /// </summary>
    public class ContractDetailFilter : PagedAndSortedInputDto
    {
        public int ContractID { get; set; }     
    }
}
