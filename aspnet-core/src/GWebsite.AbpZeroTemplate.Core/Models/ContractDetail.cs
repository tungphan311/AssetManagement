namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ContractDetail : FullAuditModel
    {
        public int ContractID { get; set; }
        public int MerchID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}