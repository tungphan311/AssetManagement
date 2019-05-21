using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssignmentTables;
using GWebsite.AbpZeroTemplate.Application.Share.AssignmentTables.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssignmentTableController : GWebsiteControllerBase
    {
        private readonly IAssignmentTableAppService AssignmentTableAppService;

        public AssignmentTableController(IAssignmentTableAppService AssignmentTableAppService)
        {
            this.AssignmentTableAppService = AssignmentTableAppService;
        }

        [HttpGet]
        public PagedResultDto<AssignmentTableDto> GetAssignmentTablesByFilter(AssignmentTableFilter AssignmentTableFilter)
        {
            return AssignmentTableAppService.GetAssignmentTables(AssignmentTableFilter);
        }

        [HttpGet]
        public AssignmentTableInput GetAssignmentTableForEdit(int id)
        {
            return AssignmentTableAppService.GetAssignmentTableForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAssignmentTable([FromBody] AssignmentTableInput input)
        {
            AssignmentTableAppService.CreateOrEditAssignmentTable(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAssignmentTable(int id)
        {
            AssignmentTableAppService.DeleteAssignmentTable(id);
        }

        [HttpGet]
        public AssignmentTableForViewDto GetAssignmentTableForView(int id)
        {
            return AssignmentTableAppService.GetAssignmentTableForViewDto(id);
        }
    }
}