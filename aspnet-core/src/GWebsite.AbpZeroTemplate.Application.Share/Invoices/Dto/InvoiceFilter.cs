using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Invoices.Dto
{
    /// <summary>
    /// <model cref="Invoice"></model>
    /// </summary>
    public class InvoiceFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public int StaffID { get; set; }
    }
}
