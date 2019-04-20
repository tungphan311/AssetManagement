using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Invoices.Dto
{
    /// <summary>
    /// <model cref="Invoice"></model>
    /// </summary>
    public class InvoiceDto : Entity<int>
    {
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public int StaffID { get; set; }
    }
}
