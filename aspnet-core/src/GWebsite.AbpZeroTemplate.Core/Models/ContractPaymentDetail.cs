using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ContractPaymentDetail : FullAuditModel
    {
        public int InstallmentNumber { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public decimal Percent { get; set; }
        public decimal Price { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        //Adding Expected Field Expand
        [StringLength(500)]
        public string Note { get; set; }


        //FK
        public int ContractId { get; set; }
        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
    }
}
