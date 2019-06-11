using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssignmentTables.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vendors;
using GWebsite.AbpZeroTemplate.Application.Share.Vendors.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Vendors
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VendorAppService : GWebsiteAppServiceBase, IVendorAppService
    {
        private readonly IRepository<Vendor> vendorRepository;
        private readonly IRepository<AssignmentTable> assignmentTableRepository;

        public VendorAppService(IRepository<Vendor> vendorRepository, IRepository<AssignmentTable> assignmentTableRepository)
        {
            this.vendorRepository = vendorRepository;
            this.assignmentTableRepository = assignmentTableRepository; 
        }

        #region Public Method

        public void CreateOrEditVendor(VendorInput vendorInput)
        {
            if (vendorInput.Id == 0)
            {
                Create(vendorInput);
            }
            else
            {
                Update(vendorInput);
            }
        }

        public void DeleteVendor(int id)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendorEntity != null)
            {
                vendorEntity.IsDelete = true;
                vendorRepository.Update(vendorEntity);

                //Xoá bảng gán tương ứng với vendor này
                var assignmentList = assignmentTableRepository.GetAll().Where(x => !x.IsDelete && x.VendorID == id);
                foreach (var assignment in assignmentList)
                {
                    assignment.IsDelete = true;
                    SetAuditEdit(assignment);
                    assignmentTableRepository.Update(assignment);
                }
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VendorInput GetVendorForEdit(int id)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendorEntity == null)
            {
                return null;
            }
            var vendorInput = ObjectMapper.Map<VendorInput>(vendorEntity);
            var assignmentTableList = assignmentTableRepository.GetAll().Where(x => x.IsDelete).Where(x => x.VendorID == id);
            vendorInput.Merchandises = assignmentTableList.Select(x => x.VendorID).ToList();

            return vendorInput;

        }

        public VendorForViewDto GetVendorForView(int id)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vendorEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VendorForViewDto>(vendorEntity);
        }

        public PagedResultDto<VendorDto> GetVendors(VendorFilter input)
        {
            var query = vendorRepository.GetAll().Where(x => !x.IsDelete);

            // filter by code 
            if (input.Code != null)
            {
                query = query.Where(x => x.Code.ToLower().Contains(input.Code.ToLower()));
            }

            // filter by name 
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name.ToLower()));
            }

            // filter by typeID
            if (input.TypeID != 0)
            {
                query = query.Where(x => x.TypeID == input.TypeID);
            }

            // filter by isActive 
            if (input.IsActive != null)
            {
                if (input.IsActive.Equals("True"))
                {
                    query = query.Where(x => x.IsActive == true);
                }
                else if (input.IsActive.Equals("False"))
                {
                    query = query.Where(x => x.IsActive == false);
                }
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
            return new PagedResultDto<VendorDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VendorDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VendorInput vendorInput)
        {
            var vendorEntity = ObjectMapper.Map<Vendor>(vendorInput);
            SetAuditInsert(vendorEntity);
            
            var id = vendorRepository.InsertAndGetId(vendorEntity);
            
            foreach (var merchandise in vendorInput.Merchandises)
            {
                var assignmentInput = new AssignmentTable();
                assignmentInput.VendorID = id;
                assignmentInput.MerchID = merchandise;
                SetAuditInsert(assignmentInput);
                assignmentTableRepository.Insert(assignmentInput);
            }

            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VendorInput vendorInput)
        {
            var vendorEntity = vendorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vendorInput.Id);
            if (vendorEntity == null)
            {
            }
            ObjectMapper.Map(vendorInput, vendorEntity);
            SetAuditEdit(vendorEntity);
            vendorRepository.Update(vendorEntity);

            var assignList = assignmentTableRepository.GetAll().Where(x => !x.IsDelete && x.VendorID == vendorInput.Id);

            foreach (var assign in assignList)
            {
                assign.IsDelete = true;
                SetAuditEdit(assign);
                assignmentTableRepository.Update(assign);
            }

            if (vendorInput.Merchandises != null)
            {
                foreach (var merchandise in vendorInput.Merchandises)
                {
                    var assignmentInput = new AssignmentTable();
                    assignmentInput.VendorID = vendorInput.Id;
                    assignmentInput.MerchID = merchandise;
                    SetAuditInsert(assignmentInput);
                    assignmentTableRepository.Insert(assignmentInput);
                }
            }

            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
