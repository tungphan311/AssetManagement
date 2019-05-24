using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssignmentTables;
using GWebsite.AbpZeroTemplate.Application.Share.AssignmentTables.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssignmentTables
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class AssignmentTableAppService : GWebsiteAppServiceBase, IAssignmentTableAppService
    {
        private readonly IRepository<AssignmentTable> AssignmentTableRepository;

        public AssignmentTableAppService(IRepository<AssignmentTable> AssignmentTableRepository)
        {
            this.AssignmentTableRepository = AssignmentTableRepository;
        }

        #region Public Method

        public void CreateOrEditAssignmentTable(AssignmentTableInput AssignmentTableInput)
        {
            if (AssignmentTableInput.Id == 0)
            {
                Create(AssignmentTableInput);
            }
            else
            {
                Update(AssignmentTableInput);
            }
        }

        public void DeleteAssignmentTable(int id)
        {
            var AssignmentTableEntity = AssignmentTableRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (AssignmentTableEntity != null)
            {
                AssignmentTableEntity.IsDelete = true;
                AssignmentTableRepository.Update(AssignmentTableEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssignmentTableInput GetAssignmentTableForEdit(int id)
        {
            var AssignmentTableEntity = AssignmentTableRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (AssignmentTableEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssignmentTableInput>(AssignmentTableEntity);
        }

        public AssignmentTableForViewDto GetAssignmentTableForViewDto(int id)
        {
            var AssignmentTableEntity = AssignmentTableRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (AssignmentTableEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssignmentTableForViewDto>(AssignmentTableEntity);
        }

        public PagedResultDto<AssignmentTableDto> GetAssignmentTables(AssignmentTableFilter input)
        {
            var query = AssignmentTableRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MerchID != 0)
            {
                query = query.Where(x => x.MerchID==input.MerchID);
            }
            if (input.VendorID != 0)
            {
                query = query.Where(x => x.VendorID == input.VendorID);
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
            return new PagedResultDto<AssignmentTableDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssignmentTableDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(AssignmentTableInput AssignmentTableInput)
        {
            var AssignmentTableEntity = ObjectMapper.Map<AssignmentTable>(AssignmentTableInput);
            SetAuditInsert(AssignmentTableEntity);
            AssignmentTableRepository.Insert(AssignmentTableEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(AssignmentTableInput AssignmentTableInput)
        {
            var AssignmentTableEntity = AssignmentTableRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == AssignmentTableInput.Id);
            if (AssignmentTableEntity == null)
            {
            }
            ObjectMapper.Map(AssignmentTableInput, AssignmentTableEntity);
            SetAuditEdit(AssignmentTableEntity);
            AssignmentTableRepository.Update(AssignmentTableEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}