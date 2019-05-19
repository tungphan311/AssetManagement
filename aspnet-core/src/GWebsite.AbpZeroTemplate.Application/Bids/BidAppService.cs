using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Bids
{
    public class BidAppService : GWebsiteAppServiceBase, IBidAppService
    {
        private readonly IRepository<Bid> BidRepository;

        public BidAppService(IRepository<Bid> BidRepository)
        {
            this.BidRepository = BidRepository;
        }

        #region Public Method

        public void CreateOrEditBid(BidInput BidInput)
        {
            if (BidInput.ProjectId != null && BidInput.ProjectId == 0)
            {
                BidInput.ProjectId = null;
            }
            if (BidInput.Id == 0)
            {
                Create(BidInput);
            }
            else
            {
                Update(BidInput);
            }
        }

        public void DeleteBid(int id)
        {
            var BidEntity = BidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BidEntity != null)
            {
                BidEntity.IsDelete = true;
                BidRepository.Update(BidEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BidInput GetBidForEdit(int id)
        {
            var BidEntity = BidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BidEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BidInput>(BidEntity);
        }

        public BidForViewDto GetBidForView(int id)
        {
            try
            {
                var BidEntity = BidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
                if (BidEntity == null)
                {
                    Console.WriteLine("Bid with id=" + id.ToString() + " is null");
                    return null;
                }
                return ObjectMapper.Map<BidForViewDto>(BidEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception Bid for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<BidDto> GetBids(BidFilter input)
        {
            var query = BidRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Code != null)
            {
                query = query.Where(x => x.Code.ToLower().StartsWith(input.Code));
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
            return new PagedResultDto<BidDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BidDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Bid_Create)]
        private void Create(BidInput BidInput)
        {
            System.Console.WriteLine("BidInput: " + BidInput.Code.ToString());
            try
            {
                var BidEntity = ObjectMapper.Map<Bid>(BidInput);
                if (BidEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(BidEntity);
                BidRepository.Insert(BidEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Bid_Edit)]
        private void Update(BidInput BidInput)
        {
            var BidEntity = BidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == BidInput.Id);
            if (BidEntity == null)
            {
            }
            ObjectMapper.Map(BidInput, BidEntity);
            SetAuditEdit(BidEntity);
            BidRepository.Update(BidEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
