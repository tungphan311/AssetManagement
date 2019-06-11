using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RoadCharges;
using GWebsite.AbpZeroTemplate.Application.Share.RoadCharges.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.RoadChargess
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class RoadChargesAppService : GWebsiteAppServiceBase, IRoadChargesAppService
    {
        private readonly IRepository<RoadCharges> roadChargesRepository;

        public RoadChargesAppService(IRepository<RoadCharges> roadChargesRepository)
        {
            this.roadChargesRepository = roadChargesRepository;
        }

        #region Public Method

        public void CreateOrEditRoadCharges(RoadChargesInput roadChargesInput)
        {
            if (roadChargesInput.Id == 0)
            {
                Create(roadChargesInput);
            }
            else
            {
                Update(roadChargesInput);
            }
        }

        public void DeleteRoadCharges(int id)
        {
            var roadChargesEntity = roadChargesRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (roadChargesEntity != null)
            {
                roadChargesEntity.IsDelete = true;
                roadChargesRepository.Update(roadChargesEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RoadChargesInput GetRoadChargesForEdit(int id)
        {
            var roadChargesEntity = roadChargesRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (roadChargesEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RoadChargesInput>(roadChargesEntity);
        }

        public RoadChargesForViewDto GetRoadChargesForView(int id)
        {
            var roadChargesEntity = roadChargesRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (roadChargesEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RoadChargesForViewDto>(roadChargesEntity);
        }

        public PagedResultDto<RoadChargesDto> GetRoadChargess(RoadChargesFilter input)
        {
            var query = roadChargesRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<RoadChargesDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RoadChargesDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(RoadChargesInput roadChargesInput)
        {
            var roadChargesEntity = ObjectMapper.Map<RoadCharges>(roadChargesInput);
            SetAuditInsert(roadChargesEntity);
            roadChargesRepository.Insert(roadChargesEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(RoadChargesInput roadChargesInput)
        {
            var roadChargesEntity = roadChargesRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == roadChargesInput.Id);
            if (roadChargesEntity == null)
            {
            }
            ObjectMapper.Map(roadChargesInput, roadChargesEntity);
            SetAuditEdit(roadChargesEntity);
            roadChargesRepository.Update(roadChargesEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}