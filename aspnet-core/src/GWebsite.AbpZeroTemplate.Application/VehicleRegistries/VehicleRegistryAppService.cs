using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRegistries.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.VehicleRegistries
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VehicleRegistryAppService : GWebsiteAppServiceBase, IVehicleRegistryAppService
    {
        private readonly IRepository<VehicleRegistry> vehicleRegistryRepository;

        public VehicleRegistryAppService(IRepository<VehicleRegistry> vehicleRegistryRepository)
        {
            this.vehicleRegistryRepository = vehicleRegistryRepository;
        }

        #region Public Method

        public void CreateOrEditVehicleRegistry(VehicleRegistryInput vehicleRegistryInput)
        {
            if (vehicleRegistryInput.Id == 0)
            {
                Create(vehicleRegistryInput);
            }
            else
            {
                Update(vehicleRegistryInput);
            }
        }

        public void DeleteVehicleRegistry(int id)
        {
            var vehicleRegistryEntity = vehicleRegistryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleRegistryEntity != null)
            {
                vehicleRegistryEntity.IsDelete = true;
                vehicleRegistryRepository.Update(vehicleRegistryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleRegistryInput GetVehicleRegistryForEdit(int id)
        {
            var vehicleRegistryEntity = vehicleRegistryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleRegistryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleRegistryInput>(vehicleRegistryEntity);
        }
        public int GetVehicleRegistryNumber(string plateNumber)
        {
            if (vehicleRegistryRepository.GetAll().Where(x => !x.IsDelete && x.PlateNumber == plateNumber) == null)
                return 1;
            return vehicleRegistryRepository.GetAll().Where(x => !x.IsDelete && x.PlateNumber == plateNumber).Max(x => x.RegisterNumber) + 1;
        }
        public VehicleRegistryForViewDto GetVehicleRegistryForView(int id)
        {
            var vehicleRegistryEntity = vehicleRegistryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleRegistryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleRegistryForViewDto>(vehicleRegistryEntity);
        }

        public PagedResultDto<VehicleRegistryDto> GetVehicleRegistries(VehicleRegistryFilter input)
        {
            var query = vehicleRegistryRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<VehicleRegistryDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleRegistryDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VehicleRegistryInput vehicleRegistryInput)
        {
            var vehicleRegistryEntity = ObjectMapper.Map<VehicleRegistry>(vehicleRegistryInput);
            SetAuditInsert(vehicleRegistryEntity);
            vehicleRegistryRepository.Insert(vehicleRegistryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VehicleRegistryInput vehicleRegistryInput)
        {
            var vehicleRegistryEntity = vehicleRegistryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vehicleRegistryInput.Id);
            if (vehicleRegistryEntity == null)
            {
            }
            ObjectMapper.Map(vehicleRegistryInput, vehicleRegistryEntity);
            SetAuditEdit(vehicleRegistryEntity);
            vehicleRegistryRepository.Update(vehicleRegistryEntity);
            CurrentUnitOfWork.SaveChanges();
        }
        #endregion
    }
}
