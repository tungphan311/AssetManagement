using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto
{
    /// <summary>
    /// <model cref="ContractDetail"></model>
    /// </summary>
    public class ContractDetailDto : Entity<int>
    {
        public int ContractID { get; set; }
        public int MerchID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
