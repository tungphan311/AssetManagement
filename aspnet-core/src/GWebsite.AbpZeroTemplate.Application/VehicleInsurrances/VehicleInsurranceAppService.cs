using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances;
using GWebsite.AbpZeroTemplate.Application.Share.VehicleInsurrances.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.VehicleInsurrances
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
   public class VehicleInsurranceAppService : GWebsiteAppServiceBase, IVehicleInsurranceAppService
    {
        private readonly IRepository<VehicleInsurrance> vehicleInsurranceRepository;

        public VehicleInsurranceAppService(IRepository<VehicleInsurrance> vehicleInsurranceRepository)
        {
            this.vehicleInsurranceRepository = vehicleInsurranceRepository;
        }

        #region Public Method

        public void CreateOrEditVehicleInsurrance(VehicleInsurranceInput vehicleInsurranceInput)
        {
            if (vehicleInsurranceInput.Id == 0)
            {
                Create(vehicleInsurranceInput);
            }
            else
            {
                Update(vehicleInsurranceInput);
            }
        }

        public void DeleteVehicleInsurrance(int id)
        {
            var vehicleInsurranceEntity = vehicleInsurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleInsurranceEntity != null)
            {
                vehicleInsurranceEntity.IsDelete = true;
                vehicleInsurranceRepository.Update(vehicleInsurranceEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleInsurranceInput GetVehicleInsurranceForEdit(int id)
        {
            var vehicleInsurranceEntity = vehicleInsurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleInsurranceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleInsurranceInput>(vehicleInsurranceEntity);
        }
        public int GetVehicleInsurranceNumber(string plateNumber)
        {
            if (vehicleInsurranceRepository.GetAll().Where(x => !x.IsDelete && x.PlateNumber == plateNumber) == null)
                return 1;
            return vehicleInsurranceRepository.GetAll().Where(x => !x.IsDelete && x.PlateNumber == plateNumber).Max(x => x.InsurranceNumber) + 1;
        }
        public VehicleInsurranceForViewDto GetVehicleInsurranceForView(int id)
        {
            var vehicleInsurranceEntity = vehicleInsurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleInsurranceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleInsurranceForViewDto>(vehicleInsurranceEntity);
        }

        public PagedResultDto<VehicleInsurranceDto> GetVehicleInsurrances(VehicleInsurranceFilter input)
        {
            var query = vehicleInsurranceRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<VehicleInsurranceDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VehicleInsurranceDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(VehicleInsurranceInput vehicleInsurranceInput)
        {
            var vehicleInsurranceEntity = ObjectMapper.Map<VehicleInsurrance>(vehicleInsurranceInput);
            SetAuditInsert(vehicleInsurranceEntity);
            vehicleInsurranceRepository.Insert(vehicleInsurranceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(VehicleInsurranceInput vehicleInsurranceInput)
        {
            var vehicleInsurranceEntity = vehicleInsurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vehicleInsurranceInput.Id);
            if (vehicleInsurranceEntity == null)
            {
            }
            ObjectMapper.Map(vehicleInsurranceInput, vehicleInsurranceEntity);
            SetAuditEdit(vehicleInsurranceEntity);
            vehicleInsurranceRepository.Update(vehicleInsurranceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion

    }
}
