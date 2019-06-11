using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs.Dto
{
    /// <summary>
    /// <model cref="VehicleRepair"></model>
    /// </summary>
    public class VehicleRepairForViewDto
    {
        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime ExpectedCompletionDate { get; set; }
        public string ExpectedRepairUnit { get; set; }
        public string ProposedUnit { get; set; }
        public int ExpectedRepairCost { get; set; }
        public string Proposer { get; set; }
        public string StaffInCharge { get; set; }
        public string ExpectedRepairContent { get; set; }
        public string Status { get; set; }
        public string Note1 { get; set; }
        public System.DateTime CompletionDate { get; set; }
        public string RepairUnit { get; set; }
        public int RepairCosts { get; set; }
        public string RepairContent { get; set; }
        public string Note2 { get; set; }
    }
}