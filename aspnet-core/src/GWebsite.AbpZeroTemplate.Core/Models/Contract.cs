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
    public class Contract : FullAuditModel
    {
        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        //[Column(TypeName = "varchar(50)")]
        //public string BidCode { get; set; }
        //[Column(TypeName = "varchar(50)")]
        //public string ProviderCode { get; set; }
        public DateTime ContractCreatedDate { get; set; }
        public Status Status { get; set; }
        [StringLength(500)]
        public string Note { get; set; }
        //
        //Contract Guarantee
        public ContractGuaranteeForm ContractGuaranteeForm { get; set; }
        [StringLength(50)]
        public string ContractCertificateNumber { get; set; }
        public DateTime ContractCertificateEndDate { get; set; }
        public DateTime ContractCertificatePrice { get; set; }
        public DateTime ContractCertificatePricePercent { get; set; }
        [StringLength(200)]
        public string ContractGuaranteeBankName { get; set; }
        public string ContractGuaranteeAttachmentFile { get; set; }

        //Warranty Guarantee
        public GuaranteeForm WarrantyGuaranteeForm { get; set; }
        [StringLength(50)]
        public string WarrantyCertificateNumber { get; set; }
        public DateTime WarrantyCertificateEndDate { get; set; }
        public DateTime WarrantyCertificatePrice { get; set; }
        public DateTime WarrantyCertificatePricePercent { get; set; }
        [StringLength(200)]
        public string WarrantyGuaranteeBankName { get; set; }
        public string WarrantyGuaranteeAttachmentFile { get; set; }
        //
        //Price
        public decimal TotalProductPrice { get; set; }
        public decimal TotalPrice { get; set; }

        //FK
        public int? BidId { get; set; }
        [ForeignKey("BidId")]
        public virtual Bid Bid { get; set; }
        public int? ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }
    }
}
