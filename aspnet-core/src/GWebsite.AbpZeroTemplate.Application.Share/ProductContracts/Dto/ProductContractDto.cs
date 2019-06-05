using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;
using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductContracts.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.ProductContract"></model>
    /// </summary>
    public class ProductContractDto : Entity<int>
    {
        public int Amount { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }


        //FK
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int ContractId { get; set; }
        public ContractDto Contract { get; set; }
    }
}
