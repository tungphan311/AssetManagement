using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class PurchaseOrder : FullAuditModel
    {
        PurchaseOrder()
        {
            IsIndependentUnit = false;
        }

        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public Area? Area { get; set; }
        public int? UnitId { get; set; }
        [StringLength(50)]
        public string UnitCode { get; set; }
        [StringLength(256)]
        public string TransactionOfficeName { get; set; }
        public bool? IsIndependentUnit { get; set; }

        [StringLength(50)]
        public string ReportCode { get; set; }

        public DateTime? ReportRecievedDate { get; set; }
        public DateTime? ReportApprovalDate { get; set; }

        public string AttachmentFile { get; set; }

        public decimal? TotalPrice { get; set; }
        //FK
        public int? ContractId { get; set; }
        public int? ProviderId { get; set; }
    }
}
