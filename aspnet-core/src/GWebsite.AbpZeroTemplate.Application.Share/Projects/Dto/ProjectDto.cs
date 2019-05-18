using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models.Enums.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto
{
    /// <summary>
    /// <model cref="GWebsite.AbpZeroTemplate.Core.Models.Project"></model>
    /// </summary>
    public class ProjectDto : Entity<int>
    {
        public string Name { get; set; }
        public string ActivityType { get; set; }
        public DateTime ProjectCreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
