using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using GWebsite.AbpZeroTemplate.Core.Models.Enums.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Bid : FullAuditModel
    {
        public string Code { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Status Status { get; set; }
        public BiddingForm BiddingForm { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ProjectCode { get; set; }
        public decimal CautionMoney { get; set; }
        public string AttachmentFile { get; set; }

        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
