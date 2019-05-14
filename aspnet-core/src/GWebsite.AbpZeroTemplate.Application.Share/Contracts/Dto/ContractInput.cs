using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto
{
    public class ContractInput : Entity<int>
    {
        [Required]
        public virtual int ContractID { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual DateTime DeliveryTime { get; set; }

        [Required]
        public virtual int BriefcaseID { get; set; }

        [Required]
        public virtual int Note { get; set; }

        [Required]
        public virtual int ContractWarrantyTypeID { get; set; }

        [Required]
        public virtual int ContractWarrantyID { get; set; }

        [Required]
        public virtual DateTime ContractWarrantyExpireDate { get; set; }

        [Required]
        public virtual int ContractWarrantyPercent { get; set; }

        [Required]
        public virtual int ContractWarrantyAmount { get; set; }

        [Required]
        public virtual int WarrantyGuaranteeTypeID { get; set; }

        [Required]
        public virtual int WarrantyGuaranteeID { get; set; }

        [Required]
        public virtual DateTime WarrantyGuaranteeExpireDate { get; set; }

        [Required]
        public virtual int WarrantyGuaranteePercent { get; set; }

        [Required]
        public virtual int WarrantyGuaranteeAmount { get; set; }
    }
}
