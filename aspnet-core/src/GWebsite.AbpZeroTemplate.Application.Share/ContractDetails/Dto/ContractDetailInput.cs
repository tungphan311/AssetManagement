﻿using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto
{
    /// <summary>
    /// <model cref="ContractDetail"></model>
    /// </summary>
    public class ContractDetailInput : Entity<int>
    {
        public int ContractID { get; set; }

        public int MerchID { get; set; }

        public string MerCode { get; set; }

        public string MerName { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public string Note { get; set; }
    }
}
