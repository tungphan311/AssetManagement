using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.Bids
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class BidAppService : GWebsiteAppServiceBase, IBidAppService
    {
        private readonly IRepository<Bid> repository;

        public BidAppService(IRepository<Bid> repository)
        {
            this.repository = repository;
        }

        #region public method

        public void CreateOrEditBid(BidInput input)
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

        public void DeleteBid(int id)
        {
            var entity = repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity != null)
            {
                entity.IsDelete = true;
                repository.Update(entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BidInput GetBidForEdit(int id)
        {
            var entity = repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return ObjectMapper.Map<BidInput>(entity);
        }

        public BidForViewDto GetBidForViewDto(int id)
        {
            var entity = repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return ObjectMapper.Map<BidForViewDto>(entity);
        }

        public PagedResultDto<BidDto> GetBids(BidFilter filter)
        {
            var query = repository.GetAll().Where(x => !x.IsDelete);

            // filter by Name 
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            // filter by Category
            if (filter.Category != null)
            {
                query = query.Where(x => x.Category.ToLower().Equals(filter.Category.ToLower()));
            }

            // filter by Date 
            if (filter.StartReceivingRecords != null)
            {
                query = query.Where(x => x.StartReceivingRecords.DayOfYear >= filter.StartReceivingRecords.DayOfYear);
            }

            if (filter.EndReceivingRecords != null)
            {
                query = query.Where(x => x.EndReceivingRecords.DayOfYear <= filter.EndReceivingRecords.DayOfYear);
            }

            if (filter.BiddingForm != null)
            {
                query = query.Where(x => x.BiddingForm.ToLower().Equals(filter.BiddingForm.ToLower()));
            }

            var totalCount = query.Count();

            // sort
            if (!string.IsNullOrWhiteSpace(filter.Sorting))
            {
                query = query.OrderBy(filter.Sorting);
            }

            // paging
            var items = query.PageBy(filter).ToList();

            // result
            return new PagedResultDto<BidDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BidDto>(item)).ToList()
            );
        }

        #endregion

        #region private method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(BidInput input)
        {
            var entity = ObjectMapper.Map<Bid>(input);
            SetAuditInsert(entity);
            repository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(BidInput input)
        {
            var entity = repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (entity == null)
            {

            }
            ObjectMapper.Map(input, entity);
            SetAuditEdit(entity);
            repository.Update(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
