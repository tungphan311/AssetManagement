using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssignmentTables.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Customers
{
    public interface IAssignmentTableAppService
    {
        void CreateOrEditAssignmentTable(AssignmentTableInput assigmentTableInput);
        AssignmentTableInput GetAssignmentTableForEdit(int id);
        void DeleteAssignmentTable(int id);
        PagedResultDto<AssignmentTableDto> GetAssignmentTables(AssignmentTableFilter input);
        AssignmentTableForViewDto GetAssignmentTableForViewDto(int id);
    }
}