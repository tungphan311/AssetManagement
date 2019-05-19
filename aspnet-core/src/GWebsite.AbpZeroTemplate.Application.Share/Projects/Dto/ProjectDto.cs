using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto
{
    /// <summary>
    /// <model cref="Project"></model>
    /// </summary>
    public class ProjectDto : Entity<int>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
