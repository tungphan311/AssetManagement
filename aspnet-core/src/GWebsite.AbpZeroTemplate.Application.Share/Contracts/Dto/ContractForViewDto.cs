﻿using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto
{
    public class ContractForViewDto
    {
        public string ContractID { get; set; }
        public string Name { get; set; }
        public DateTime DeliveryTime { get; set; }
        public int BriefcaseID { get; set; }
        public int VendorID { get; set; }
        public string Note { get; set; }

        public string ContractWarrantyType { get; set; }
        public string ContractWarrantyID { get; set; }
        public DateTime ContractWarrantyExpireDate { get; set; }
        public float ContractWarrantyPercent { get; set; }
        public float ContractWarrantyAmount { get; set; }
        public string ContractWarrantyBank { get; set; }
        public string ContractWarrantyFile { get; set; }

        public int WarrantyGuaranteeTypeID { get; set; }
        public int WarrantyGuaranteeID { get; set; }
        public DateTime WarrantyGuaranteeExpireDate { get; set; }
        public int WarrantyGuaranteePercent { get; set; }
        public int WarrantyGuaranteeAmount { get; set; }
        public string WarrantyGuaranteeBank { get; set; }
        public string WarrantyGuaranteeFile { get; set; }
    }
}
