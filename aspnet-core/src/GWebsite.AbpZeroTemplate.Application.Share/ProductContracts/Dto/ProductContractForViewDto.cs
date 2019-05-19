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
    public class ProductContractForViewDto
    {
        public int Amount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }


        //FK
        public int ProductId { get; set; }
        public virtual ProductDto Product { get; set; }

        public int ContractId { get; set; }
        public virtual ContractDto Contract { get; set; }

    }
}
