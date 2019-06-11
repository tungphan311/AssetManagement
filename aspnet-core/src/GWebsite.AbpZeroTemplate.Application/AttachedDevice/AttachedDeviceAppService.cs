using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices;
using GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.AttachedDevices
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class AttachedDeviceAppService : GWebsiteAppServiceBase, IAttachedDeviceAppService
    {
        private readonly IRepository<AttachedDevice> attachedDeviceRepository;

        public AttachedDeviceAppService(IRepository<AttachedDevice> attachedDeviceRepository)
        {
            this.attachedDeviceRepository = attachedDeviceRepository;
        }

        #region Public Method

        public void CreateOrEditAttachedDevice(AttachedDeviceInput attachedDeviceInput)
        {
            if (attachedDeviceInput.Id == 0)
            {
                Create(attachedDeviceInput);
            }
            else
            {
                Update(attachedDeviceInput);
            }
        }

        public void DeleteAttachedDevice(int id)
        {
            var attachedDeviceEntity = attachedDeviceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (attachedDeviceEntity != null)
            {
                attachedDeviceEntity.IsDelete = true;
                attachedDeviceRepository.Update(attachedDeviceEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AttachedDeviceInput GetAttachedDeviceForEdit(int id)
        {
            var attachedDeviceEntity = attachedDeviceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (attachedDeviceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AttachedDeviceInput>(attachedDeviceEntity);
        }

        public AttachedDeviceForViewDto GetAttachedDeviceForView(int id)
        {
            var attachedDeviceEntity = attachedDeviceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (attachedDeviceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AttachedDeviceForViewDto>(attachedDeviceEntity);
        }

        public PagedResultDto<AttachedDeviceDto> GetAttachedDevices(AttachedDeviceFilter input)
        {
            var query = attachedDeviceRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.PlateNumber != null)
            {
                query = query.Where(x => x.PlateNumber.ToLower().Equals(input.PlateNumber));
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
            return new PagedResultDto<AttachedDeviceDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AttachedDeviceDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(AttachedDeviceInput attachedDeviceInput)
        {
            var attachedDeviceEntity = ObjectMapper.Map<AttachedDevice>(attachedDeviceInput);
            SetAuditInsert(attachedDeviceEntity);
            attachedDeviceRepository.Insert(attachedDeviceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(AttachedDeviceInput attachedDeviceInput)
        {
            var attachedDeviceEntity = attachedDeviceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == attachedDeviceInput.Id);
            if (attachedDeviceEntity == null)
            {
            }
            ObjectMapper.Map(attachedDeviceInput, attachedDeviceEntity);
            SetAuditEdit(attachedDeviceEntity);
            attachedDeviceRepository.Update(attachedDeviceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}