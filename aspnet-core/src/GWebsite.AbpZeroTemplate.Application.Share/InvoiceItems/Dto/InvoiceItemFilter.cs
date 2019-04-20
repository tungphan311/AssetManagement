using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems.Dto
{
    /// <summary>
    /// <model cref="InvoiceItem"></model>
    /// </summary>
    public class InvoiceItemFilter : PagedAndSortedInputDto
    {
        public int InvoiceID { get; set; }
        public int AssetID { get; set; }     
    }
}
