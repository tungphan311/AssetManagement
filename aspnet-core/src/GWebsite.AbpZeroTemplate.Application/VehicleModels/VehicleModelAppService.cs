using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleModels;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleModels.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.VehicleModels
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class VehicleModelAppService : GWebsiteAppServiceBase, IVehicleModelAppService
    {
        private readonly IRepository<VehicleModel> vehicleModelRepository;

        public VehicleModelAppService(IRepository<VehicleModel> vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }

        #region Public Method

        public void CreateOrEditVehicleModel(VehicleModelInput vehicleModelInput)
        {
            if (vehicleModelInput.Id == 0)
            {
                Create(vehicleModelInput);
            }
            else
            {
                Update(vehicleModelInput);
            }
        }

        public void DeleteVehicleModel(int id)
        {
            var vehicleModelEntity = vehicleModelRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleModelEntity != null)
            {
                vehicleModelEntity.IsDelete = true;
                vehicleModelRepository.Update(vehicleModelEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleModelInput GetVehicleModelForEdit(int id)
        {
            var vehicleModelEntity = vehicleModelRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleModelEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleModelInput>(vehicleModelEntity);
        }

        public VehicleModelForViewDto GetVehicleModelForView(int id)
        {
            var vehicleModelEntity = vehicleModelRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleModelEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleModelForViewDto>(vehicleModelEntity);
        }

        public PagedResultDto<VehicleModelDto> GetVehicleModels(VehicleModelFilter input)
        {
            var query = vehicleModelRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Model != null)
            {
                query = query.Where(x => x.Model.ToLower().Equals(input.Model));
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
            return new PagedResultDto<VehicleModelDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleModelDto>(item)).ToList());
        }

        public PagedResultDto<VehicleModelDto> GetAllVehicleModels()
        {
            var query = vehicleModelRepository.GetAll().Where(x => !x.IsDelete);

            var totalCount = query.Count();

            var items = query.ToList();

            // result
            return new PagedResultDto<VehicleModelDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleModelDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VehicleModelInput vehicleModelInput)
        {
            var vehicleModelEntity = ObjectMapper.Map<VehicleModel>(vehicleModelInput);
            SetAuditInsert(vehicleModelEntity);
            vehicleModelRepository.Insert(vehicleModelEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VehicleModelInput vehicleModelInput)
        {
            var vehicleModelEntity = vehicleModelRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vehicleModelInput.Id);
            if (vehicleModelEntity == null)
            {
            }
            ObjectMapper.Map(vehicleModelInput, vehicleModelEntity);
            SetAuditEdit(vehicleModelEntity);
            vehicleModelRepository.Update(vehicleModelEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}