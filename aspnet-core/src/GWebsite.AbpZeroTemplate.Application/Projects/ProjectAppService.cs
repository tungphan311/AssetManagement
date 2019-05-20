using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Projects;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Projects
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ProjectAppService : GWebsiteAppServiceBase, IProjectAppService
    {
        private readonly IRepository<Project> projectRepository;

        public ProjectAppService(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        #region Public Method

        public void CreateOrEditProject(ProjectInput projectInput)
        {
            if (projectInput.Id == 0)
            {
                Create(projectInput);
            }
            else
            {
                Update(projectInput);
            }
        }

        public void DeleteProject(int id)
        {
            var projectEntity = projectRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (projectEntity != null)
            {
                projectEntity.IsDelete = true;
                projectRepository.Update(projectEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ProjectInput GetProjectForEdit(int id)
        {
            var projectEntity = projectRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (projectEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProjectInput>(projectEntity);
        }

        public ProjectForViewDto GetProjectForView(int id)
        {
            var projectEntity = projectRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (projectEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProjectForViewDto>(projectEntity);
        }

        public PagedResultDto<ProjectDto> GetProjects(ProjectFilter input)
        {
            var query = projectRepository.GetAll().Where(x => !x.IsDelete);

           

            // filter by name 
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name.ToLower()));
            }

            if (input.ProjectID != null)
            {
                query = query.Where(x => x.ProjectID.ToLower().Contains(input.ProjectID.ToLower()));
            }

            if (input.DayCreate != null)
            {
                query = query.Where(x => x.DayCreate.DayOfYear >= input.DayCreate.DayOfYear);
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ProjectDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProjectDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(ProjectInput projectInput)
        {
            var projectEntity = ObjectMapper.Map<Project>(projectInput);
            SetAuditInsert(projectEntity);
            projectRepository.Insert(projectEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(ProjectInput projectInput)
        {
            var projectEntity = projectRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == projectInput.Id);
            if (projectEntity == null)
            {
            }
            ObjectMapper.Map(projectInput, projectEntity);
            SetAuditEdit(projectEntity);
            projectRepository.Update(projectEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
