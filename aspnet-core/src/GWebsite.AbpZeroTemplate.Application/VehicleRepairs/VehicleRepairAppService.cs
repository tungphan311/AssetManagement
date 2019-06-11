using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleRepairs.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.VehicleRepairs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VehicleRepairAppService : GWebsiteAppServiceBase, IVehicleRepairAppService
    {
        private readonly IRepository<VehicleRepair> vehicleRepository;

        public VehicleRepairAppService(IRepository<VehicleRepair> vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        #region Public Method

        public void CreateOrEditVehicleRepair(VehicleRepairInput vehicleInput)
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

        public void DeleteVehicleRepair(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity != null)
            {
                vehicleEntity.IsDelete = true;
                vehicleRepository.Update(vehicleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleRepairInput GetVehicleRepairForEdit(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleRepairInput>(vehicleEntity);
        }
        public VehicleRepairInput GetVehicleRepairByAssetForEdit(string assetId)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.AssetId == assetId);
            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleRepairInput>(vehicleEntity);
        }

        public VehicleRepairForViewDto GetVehicleRepairForView(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleRepairForViewDto>(vehicleEntity);
        }

        public PagedResultDto<VehicleRepairDto> GetVehicleRepairs(VehicleRepairFilter input)
        {
            var query = vehicleRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.AssetId != null)
            {
                query = query.Where(x => x.AssetId.ToLower().Equals(input.AssetId));
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
            return new PagedResultDto<VehicleRepairDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleRepairDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VehicleRepairInput vehicleInput)
        {
            var vehicleEntity = ObjectMapper.Map<VehicleRepair>(vehicleInput);
            SetAuditInsert(vehicleEntity);
            vehicleRepository.Insert(vehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VehicleRepairInput vehicleInput)
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