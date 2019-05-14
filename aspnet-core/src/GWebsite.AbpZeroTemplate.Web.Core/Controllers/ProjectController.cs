using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProjectController : GWebsiteControllerBase
    {
        private readonly IProjectAppService projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            this.projectAppService = projectAppService;
        }

        [HttpGet]
        public PagedResultDto<ProjectDto> GetProjectsByFilter(ProjectFilter projectFilter)
        {
            return projectAppService.GetProjects(projectFilter);
        }

        [HttpGet]
        public ProjectInput GetProjectForEdit(int id)
        {
            return projectAppService.GetProjectForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditProject([FromBody] ProjectInput input)
        {
            projectAppService.CreateOrEditProject(input);
        }

        [HttpDelete("{id}")]
        public void DeleteProject(int id)
        {
            projectAppService.DeleteProject(id);
        }

        [HttpGet]
        public ProjectForViewDto GetProjectForView(int id)
        {
            return projectAppService.GetProjectForView(id);
        }
    }
}
