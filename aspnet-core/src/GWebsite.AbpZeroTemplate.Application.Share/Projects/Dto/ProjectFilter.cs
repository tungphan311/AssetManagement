using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto
{
    public class ProjectFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
