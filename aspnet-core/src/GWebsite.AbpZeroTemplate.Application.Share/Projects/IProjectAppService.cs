using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects
{
    public interface IProjectAppService
    {
        void CreateOrEditProject(ProjectInput projectInput);
        ProjectInput GetProjectForEdit(int id);
        void DeleteProject(int id);
        PagedResultDto<ProjectDto> GetProjects(ProjectFilter input);
        ProjectForViewDto GetProjectForView(int id);
    }
}
