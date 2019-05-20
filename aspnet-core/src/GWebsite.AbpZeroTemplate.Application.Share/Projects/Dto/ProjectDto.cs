using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto
{
    /// <summary>
    /// <model cref="Project"></model>
    /// </summary>
    public class ProjectDto : Entity<int>
    {
        public string ProjectID { get; set; }

        public string Name { get; set; }

        public DateTime DayCreate { get; set; }

        public bool IsActive { get; set; }
    }
}
