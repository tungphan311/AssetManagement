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
using GWebsite.AbpZeroTemplate.Application.Share.Bidders.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.Bids
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class BidAppService : GWebsiteAppServiceBase, IBidAppService
    {
        private readonly IRepository<Bid> bidRepository;
        private readonly IRepository<Bidder> bidderRepository;

        public BidAppService(IRepository<Bid> bidRepository,IRepository<Bidder> bidderRepository)
        {
            this.bidRepository = bidRepository;
            this.bidderRepository = bidderRepository;
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
            var entity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity != null)
            {
                entity.IsDelete = true;
                bidRepository.Update(entity);
                //xóa bidder của bid đó 
                var ListBidders = bidderRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.BidID == entity.Id);          
                foreach (var bidder in ListBidders)
                {
                    bidder.IsDelete = true;
                    SetAuditEdit(bidder);
                    bidderRepository.Update(bidder);
                }
                //--
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BidInput GetBidForEdit(int id)
        {
            var entity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }
            var bidInput = ObjectMapper.Map<BidInput>(entity);
            var bidderList = bidderRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.BidID == bidInput.Id);
            bidInput.Bidders = bidderList.Select(x => ObjectMapper.Map<BidderInput>(x)).ToList();

            return bidInput;
        }

        public BidForViewDto GetBidForView(int id)
        {
            var entity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return ObjectMapper.Map<BidForViewDto>(entity);
        }

        public PagedResultDto<BidDto> GetBids(BidFilter filter)
        {
            var query = bidRepository.GetAll().Where(x => !x.IsDelete);

            // filter by Name 
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            // filter by Category
            if (filter.Category != null)
            {
                query = query.Where(x => x.Category.ToLower().Contains(filter.Category.ToLower()));
            }

            // filter by Date 
            if (filter.StartReceivingRecords != null)
            {
                DateTime dt = DateTime.ParseExact(filter.StartReceivingRecords, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                dt = dt.ToUniversalTime();
                query = query.Where(x => x.BeginDay.DayOfYear > dt.DayOfYear);
            }

            if (filter.EndReceivingRecords != null)
            {
                DateTime dt = DateTime.ParseExact(filter.EndReceivingRecords, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                dt = dt.ToUniversalTime();
                query = query.Where(x => x.BeginDay.DayOfYear < dt.DayOfYear);
            }
            if (filter.VendorId != 0)
            {
                query = query.Where(x => x.BidderID == filter.VendorId);
            }

            if (filter.BiddingForm != "All")
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
                    
            var bidDTOList = items.Select(item => ObjectMapper.Map<BidDto>(item)).ToList();
                      
            // result
            return new PagedResultDto<BidDto>(
                totalCount,
                bidDTOList
            );
        }

        #endregion

        #region private method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(BidInput input)
        {
            var entity = ObjectMapper.Map<Bid>(input);
            SetAuditInsert(entity);
            bidRepository.Insert(entity);

            var id = bidRepository.InsertAndGetId(entity);

            foreach (var bidder in input.Bidders)
            {
                
                bidder.BidID = id;
                var bidderEntity = ObjectMapper.Map<Bidder>(bidder);
                SetAuditInsert(bidderEntity);
                bidderRepository.Insert(bidderEntity);
            }

            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(BidInput input)
        {
            var entity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (entity == null)
            {
                return; 
            }                       
            ObjectMapper.Map(input, entity);
            SetAuditEdit(entity);
            bidRepository.Update(entity);
            if (input.Bidders == null)
            {
                var ListBidders = bidderRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.BidID == input.Id);
                //nếu danh sách bidder rỗng thì xóa hết bidder của bid đó
                foreach (var bidder in ListBidders)
                {                  
                        bidder.IsDelete = true;
                        SetAuditEdit(bidder);
                        bidderRepository.Update(bidder);                   
                }
                return;
            }
            else
            {
                //update bidder here
                var ListBidders = bidderRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.BidID == input.Id);
                //xóa bidder cũ
                foreach (var bidder in ListBidders)
                {
                    if (!(input.Bidders.Exists(x => x.VendorId == bidder.VendorId)))
                    {
                        //nếu không tồn tại trong list của input thì xóa
                        bidder.IsDelete = true;
                        SetAuditEdit(bidder);
                        bidderRepository.Update(bidder);
                    }
                }
                //sửa hoặc thêm bidder
                foreach (var bidder in input.Bidders)
                {
                    var bidderEntity = ListBidders.SingleOrDefault(x => x.VendorId == bidder.VendorId);
                    if (bidderEntity == null)
                    {
                        //nếu không tồn tại thì thêm
                        bidderEntity = ObjectMapper.Map<Bidder>(bidder);
                        bidderEntity.BidID = entity.Id;
                        SetAuditInsert(bidderEntity);
                        bidderRepository.Insert(bidderEntity);
                    }
                    else
                    {
                        //nếu tồn tại thì update
                        bidder.Id = bidderEntity.Id;//
                        ObjectMapper.Map(bidder, bidderEntity);
                        bidderEntity.BidID = entity.Id;
                        SetAuditEdit(bidderEntity);
                        bidderRepository.Update(bidderEntity);
                    }
                }
            }
            //--
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
