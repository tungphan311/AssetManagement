using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleOperations.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.VehicleOperations
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VehicleOperationAppService : GWebsiteAppServiceBase, IVehicleOperationAppService
    {
        private readonly IRepository<VehicleOperation> vehicleOperationRepository;

        public VehicleOperationAppService(IRepository<VehicleOperation> vehicleOperationRepository)
        {
            this.vehicleOperationRepository = vehicleOperationRepository;
        }

        #region Public Method

        public void CreateOrEditVehicleOperation(VehicleOperationInput vehicleOperationInput)
        {
            if (vehicleOperationInput.Id == 0)
            {
                Create(vehicleOperationInput);
            }
            else
            {
                Update(vehicleOperationInput);
            }
        }

        public void DeleteVehicleOperation(int id)
        {
            var vehicleOperationEntity = vehicleOperationRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleOperationEntity != null)
            {
                vehicleOperationEntity.IsDelete = true;
                vehicleOperationRepository.Update(vehicleOperationEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleOperationInput GetVehicleOperationForEdit(int id)
        {
            var vehicleOperationEntity = vehicleOperationRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleOperationEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleOperationInput>(vehicleOperationEntity);
        }

        public VehicleOperationForViewDto GetVehicleOperationForView(int id)
        {
            var vehicleOperationEntity = vehicleOperationRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleOperationEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleOperationForViewDto>(vehicleOperationEntity);
        }

        public float GetLatestVehicleIndex(float currentKm, int id, string plateNumber)
        {
            var vehicleOperationEntity = vehicleOperationRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleOperationEntity == null)
                return vehicleOperationRepository.GetAll().Where(x => !x.IsDelete && x.PlateNumber == plateNumber).Max(x => x.VehicleIndex);
            else
                return vehicleOperationRepository.GetAll().Where(x => !x.IsDelete && x.PlateNumber == plateNumber && x.VehicleIndex < currentKm).Max(x => x.VehicleIndex);
        }

        public PagedResultDto<VehicleOperationDto> GetVehicleOperations(VehicleOperationFilter input)
        {
            var query = vehicleOperationRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<VehicleOperationDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleOperationDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VehicleOperationInput vehicleOperationInput)
        {
            var vehicleOperationEntity = ObjectMapper.Map<VehicleOperation>(vehicleOperationInput);
            SetAuditInsert(vehicleOperationEntity);
            vehicleOperationRepository.Insert(vehicleOperationEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VehicleOperationInput vehicleOperationInput)
        {
            var vehicleOperationEntity = vehicleOperationRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vehicleOperationInput.Id);
            if (vehicleOperationEntity == null)
            {
            }
            ObjectMapper.Map(vehicleOperationInput, vehicleOperationEntity);
            SetAuditEdit(vehicleOperationEntity);
            vehicleOperationRepository.Update(vehicleOperationEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}