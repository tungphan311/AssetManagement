namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ContractDetail : FullAuditModel
    {
        public int ContractID { get; set; }

        public int MerchID { get; set; }

        public string MerCode { get; set; }

        public string MerName { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public string Note { get; set; }
    }
}