using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.InvoiceItems.Dto
{
    /// <summary>
    /// <model cref="InvoiceItem"></model>
    /// </summary>
    public class InvoiceItemForViewDto
    {
        public int InvoiceID { get; set; }
        public int AssetID { get; set; }
        public int Quantity { get; set; }
    }
}
