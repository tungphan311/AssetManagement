using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PurchaseProductDetails.Dto
{
    public class PurchaseProductDetailDto : Entity<int>
    {
        public string ProductCategory { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal? VAT_Percent { get; set; }
        public decimal? VAT { get; set; }
        public bool IsInProject { get; set; }
        [StringLength(500)]
        public string Note { get; set; }

        //FK
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int PurchaseOrderId { get; set; }
        public PurchaseOrderDto PurchaseOrder { get; set; }
        public int? UnitId { get; set; }
        public int? ContractId { get; set; }
        public ContractDto Contract { get; set; }
        public int? ProjectId { get; set; }
        public ProjectDto Project { get; set; }
    }
}
