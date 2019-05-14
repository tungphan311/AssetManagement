using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Projects;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Web.Core.Projects;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Projects
{
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
            try
            {
                var projectEntity = projectRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
                if (projectEntity == null)
                {
                    Console.WriteLine("Project with id=" + id.ToString() + " is null");
                    return null;
                }
                return ObjectMapper.Map<ProjectForViewDto>(projectEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception Project for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<ProjectDto> GetProjects(ProjectFilter input)
        {
            var query = projectRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(input.Name));
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

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Project_Create)]
        private void Create(ProjectInput projectInput)
        {
            System.Console.WriteLine("ProjectInput: " + projectInput.Name.ToString());
            try
            {
                var projectEntity = ObjectMapper.Map<Project>(projectInput);
                if (projectEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(projectEntity);
                projectRepository.Insert(projectEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Project_Edit)]
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
