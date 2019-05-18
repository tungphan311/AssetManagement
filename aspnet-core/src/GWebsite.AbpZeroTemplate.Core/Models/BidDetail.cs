using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class BidDetail : Entity<int>
    {

        public bool IsAccepted { get; set; }
        public DateTime? BiddingCreatedDate { get; set; }
        public string AttachmentFile { get; set; }
        public decimal BidPrice { get; set; }
        public GuaranteeForm GuaranteeForm { get; set; }
        public DateTime? GuaranteeEndDate { get; set; }
        [StringLength(50)]
        public string CertificateNumber { get; set; }
        [StringLength(100)]
        public string BankName { get; set; }
        [StringLength(500)]
        public string Note { get; set; }


        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }
    }
}
