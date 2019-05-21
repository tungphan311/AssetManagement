using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.POs;
using GWebsite.AbpZeroTemplate.Application.Share.POs.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.POs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class POAppService : GWebsiteAppServiceBase, IPOAppService
    {
        private readonly IRepository<PO> poRepository;

        public POAppService(IRepository<PO> repository)
        {
            poRepository = repository;
        }

        #region public method

        public void CreateOrEditPO(POInput input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Update(input);
            }
        }

        public void DeletePO(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDelete = true;
                poRepository.Update(entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public POInput GetPOForEdit(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<POInput>(entity);
        }

        public POForViewDto GetPOForView(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<POForViewDto>(entity);
        }

        public PagedResultDto<PODto> GetPOs(POFilter input)
        {
            var query = poRepository.GetAll().Where(x => !x.IsDelete);

            if (input.POID != 0)
            {
                query = query.Where(x => x.POID == input.POID);
            }

            if (input.CreateDay != null)
            {
                query = query.Where(x => x.CreateDay.DayOfYear >= input.CreateDay.DayOfYear);
            }

            if (input.OrderName != null)
            {
                query = query.Where(x => x.OrderName.ToLower().Contains(input.OrderName.ToLower()));
            }

            if (input.ContractID != 0)
            {
                query = query.Where(x => x.ContractID == input.ContractID);
            }

            var totalCount = query.Count();

            // sort
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<PODto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PODto>(item)).ToList());
        }

        #endregion

        #region private method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(POInput input)
        {
            var entity = ObjectMapper.Map<PO>(input);
            SetAuditInsert(entity);
            poRepository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(POInput input)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (entity == null)
            {

            }
            ObjectMapper.Map(input, entity);
            SetAuditEdit(entity);
            poRepository.Update(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
