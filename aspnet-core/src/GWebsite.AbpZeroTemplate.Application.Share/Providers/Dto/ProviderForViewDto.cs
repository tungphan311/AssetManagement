using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto
{
    public class ProviderForViewDto
    {
        public string Name { get; set; }
        public decimal ProviderCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
    }
}
