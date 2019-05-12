using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto
{
    public class ProviderFilter : PagedAndSortedInputDto
    {
        /// <summary>
        /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.Provider"></model>
        /// </summary>
        public string Name { get; set; }
    }
}
