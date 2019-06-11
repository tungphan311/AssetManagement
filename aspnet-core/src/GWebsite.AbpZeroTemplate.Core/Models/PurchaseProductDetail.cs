using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class PurchaseProductDetail : Entity<int>
    {

        public string ProductCategory { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal? VAT_Percent { get; set; }
        public decimal? VAT { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }
        [StringLength(100)]
        public string ContactPhoneNumber { get; set; }
        [StringLength(256)]
        public string ContactAddress { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(500)]
        public string Note { get; set; }

        //FK
        public int ProductId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int? UnitId { get; set; }
        public int? ContractId { get; set; }
        public int? ProjectId { get; set; }

    }
}
