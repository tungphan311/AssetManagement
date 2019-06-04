using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset5s.Dto
{
    /// <summary>
    /// <model cref="Asset5"></model>
    /// </summary>
    public class Asset5Filter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
