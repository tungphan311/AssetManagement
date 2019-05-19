using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.BidDetail"></model>
    /// </summary>
    public class BidDetailFilter : PagedAndSortedInputDto
    {
        public int BidId { get; set; }
    }
}
