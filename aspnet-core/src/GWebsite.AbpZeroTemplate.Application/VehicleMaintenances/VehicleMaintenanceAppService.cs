using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleMaintenances.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.VehicleMaintenances
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VehicleMaintenanceAppService : GWebsiteAppServiceBase, IVehicleMaintenanceAppService
    {
        private readonly IRepository<VehicleMaintenance> vehicleMaintenanceRepository;

        public VehicleMaintenanceAppService(IRepository<VehicleMaintenance> vehicleMaintenanceRepository)
        {
            this.vehicleMaintenanceRepository = vehicleMaintenanceRepository;
        }

        #region Public Method

        public void CreateOrEditVehicleMaintenance(VehicleMaintenanceInput vehicleMaintenanceInput)
        {
            if (vehicleMaintenanceInput.Id == 0)
            {
                Create(vehicleMaintenanceInput);
            }
            else
            {
                Update(vehicleMaintenanceInput);
            }
        }

        public void DeleteVehicleMaintenance(int id)
        {
            var vehicleMaintenanceEntity = vehicleMaintenanceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleMaintenanceEntity != null)
            {
                vehicleMaintenanceEntity.IsDelete = true;
                vehicleMaintenanceRepository.Update(vehicleMaintenanceEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleMaintenanceInput GetVehicleMaintenanceForEdit(int id)
        {
            var vehicleMaintenanceEntity = vehicleMaintenanceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleMaintenanceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleMaintenanceInput>(vehicleMaintenanceEntity);
        }

        public VehicleMaintenanceForViewDto GetVehicleMaintenanceForView(int id)
        {
            var vehicleMaintenanceEntity = vehicleMaintenanceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleMaintenanceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleMaintenanceForViewDto>(vehicleMaintenanceEntity);
        }

        public int GetVehicleMaintenanceNumber(string plateNumber)
        {
            var vehicleMaintenanceEntity = vehicleMaintenanceRepository.GetAll().Where(x => !x.IsDelete && x.PlateNumber == plateNumber);
            if (vehicleMaintenanceEntity == null)
                return 1;
            return vehicleMaintenanceEntity.Max(x => x.NumberMaintenanceTimes) + 1;
        }

        public PagedResultDto<VehicleMaintenanceDto> GetVehicleMaintenances(VehicleMaintenanceFilter input)
        {
            var query = vehicleMaintenanceRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<VehicleMaintenanceDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleMaintenanceDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VehicleMaintenanceInput vehicleMaintenanceInput)
        {
            var vehicleMaintenanceEntity = ObjectMapper.Map<VehicleMaintenance>(vehicleMaintenanceInput);
            SetAuditInsert(vehicleMaintenanceEntity);
            vehicleMaintenanceRepository.Insert(vehicleMaintenanceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VehicleMaintenanceInput vehicleMaintenanceInput)
        {
            var vehicleMaintenanceEntity = vehicleMaintenanceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vehicleMaintenanceInput.Id);
            if (vehicleMaintenanceEntity == null)
            {
            }
            ObjectMapper.Map(vehicleMaintenanceInput, vehicleMaintenanceEntity);
            SetAuditEdit(vehicleMaintenanceEntity);
            vehicleMaintenanceRepository.Update(vehicleMaintenanceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}