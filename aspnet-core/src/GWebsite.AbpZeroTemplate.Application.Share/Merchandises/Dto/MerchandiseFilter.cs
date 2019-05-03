using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandises.Dto
{
    public class MerchandiseFilter: PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
