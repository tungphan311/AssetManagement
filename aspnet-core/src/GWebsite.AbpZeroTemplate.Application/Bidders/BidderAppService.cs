using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Bidders;
using GWebsite.AbpZeroTemplate.Application.Share.Bidders.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.Bidders
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class BidderAppService: GWebsiteAppServiceBase, IBidderAppService
    {
        private readonly IRepository<Bidder> bidRepository;

        public BidderAppService(IRepository<Bidder> repository)
        {
            bidRepository = repository;
        }

        #region public method

        public void CreateOrEditBidder(BidderInput input)
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

        public void DeleteBidder(int id)
        {
            var entity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity != null)
            {
                entity.IsDelete = true;
                bidRepository.Update(entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BidderInput GetBidderForEdit(int id)
        {
            var entity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return ObjectMapper.Map<BidderInput>(entity);
        }

        public PagedResultDto<BidderDto> GetBidders(BidderFilter filter)
        {
            var query = bidRepository.GetAll().Where(x => !x.IsDelete);

            if (filter.BidId != 0)
            {
                query = query.Where(x => x.BidID == filter.BidId);
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
            return new PagedResultDto<BidderDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BidderDto>(item)).ToList());
        }

        #endregion

        #region private method 

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(BidderInput input)
        {
            var entity = ObjectMapper.Map<Bidder>(input);
            SetAuditInsert(entity);
            bidRepository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(BidderInput input)
        {
            var entity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (entity == null)
            {

            }
            ObjectMapper.Map(input, entity);
            SetAuditEdit(entity);
            bidRepository.Update(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
