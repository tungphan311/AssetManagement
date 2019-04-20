namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Invoice : FullAuditModel
    {
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public int StaffID { get; set; }
    }
}
