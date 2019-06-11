using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Vehicles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VehicleAppService : GWebsiteAppServiceBase, IVehicleAppService
    {
        private readonly IRepository<Vehicle> vehicleRepository;

        public VehicleAppService(IRepository<Vehicle> vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        #region Public Method

        public void CreateOrEditVehicle(VehicleInput vehicleInput)
        {
            if (vehicleInput.Id == 0)
            {
                Create(vehicleInput);
            }
            else
            {
                Update(vehicleInput);
            }
        }

        public void DeleteVehicle(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity != null)
            {
                vehicleEntity.IsDelete = true;
                vehicleRepository.Update(vehicleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleInput GetVehicleForEdit(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleInput>(vehicleEntity);
        }
        public VehicleInput GetVehicleByAssetForEdit(string assetId)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.AssetId == assetId);
            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleInput>(vehicleEntity);
        }

        public VehicleForViewDto GetVehicleForView(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleForViewDto>(vehicleEntity);
        }

        public PagedResultDto<VehicleDto> GetVehicles(VehicleFilter input)
        {
            var query = vehicleRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<VehicleDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VehicleInput vehicleInput)
        {
            var vehicleEntity = ObjectMapper.Map<Vehicle>(vehicleInput);
            SetAuditInsert(vehicleEntity);
            vehicleRepository.Insert(vehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VehicleInput vehicleInput)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vehicleInput.Id);
            if (vehicleEntity == null)
            {
            }
            ObjectMapper.Map(vehicleInput, vehicleEntity);
            SetAuditEdit(vehicleEntity);
            vehicleRepository.Update(vehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}