using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductProviders.Dto
{
    public class ProductProviderDto : Entity<int>
    {
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
    }
}
