using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.ContractPaymentDetail"></model>
    /// </summary>
    public class ContractPaymentDetailInput : Entity<int>
    {
        public int InstallmentNumber { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public decimal Percent { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        //Adding Expected Field Expand

        public string Note { get; set; }


        //FK
        public int ContractId { get; set; }


    }
}
