using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.BidDetails
{
    public class BidDetailAppService : GWebsiteAppServiceBase, IBidDetailAppService
    {
        private readonly IRepository<BidDetail> bidDetailRepository;

        public BidDetailAppService(IRepository<BidDetail> bidDetailRepository)
        {
            this.bidDetailRepository = bidDetailRepository;
        }

        #region Public Method

        public void CreateOrEditBidDetail(BidDetailInput BidDetailInput)
        {

            if (BidDetailInput.Id == 0)
            {
                Create(BidDetailInput);
            }
            else
            {
                Update(BidDetailInput);
            }
        }

        public void DeleteBidDetail(int id)
        {
            var BidDetailEntity = bidDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
            if (BidDetailEntity != null)
            {
                //BidDetailEntity.IsDelete = true;
                bidDetailRepository.Delete(BidDetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public void DeleteMultiBidDetail(int bidId)
        {
            bidDetailRepository.DeleteAsync(x => x.BidId == bidId);
        }

        public BidDetailInput GetBidDetailForEdit(int id)
        {
            var BidDetailEntity = bidDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
            if (BidDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BidDetailInput>(BidDetailEntity);
        }

        public BidDetailForViewDto GetBidDetailForView(int id)
        {
            try
            {
                var BidDetailEntity = bidDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == id);
                if (BidDetailEntity == null)
                {
                    Console.WriteLine("BidDetail with id=" + id.ToString() + " is null");
                    return null;
                }
                return ObjectMapper.Map<BidDetailForViewDto>(BidDetailEntity);
            }
            catch (Exception e) { Console.WriteLine("Exception BidDetail for View: " + e.ToString()); return null; }
        }

        public PagedResultDto<BidDetailDto> GetBidDetails(BidDetailFilter input)
        {
            var query = bidDetailRepository.GetAll()/*.Where(x => !x.IsDelete);*/;

            // filter by value

            query = query.Where(x => x.BidId == input.BidId);

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<BidDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BidDetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_BidDetail_Create)]
        private void Create(BidDetailInput BidDetailInput)
        {
            try
            {
                var BidDetailEntity = ObjectMapper.Map<BidDetail>(BidDetailInput);
                if (BidDetailEntity == null) System.Console.WriteLine("null: ");
                //SetAuditInsert(BidDetailEntity);
                bidDetailRepository.Insert(BidDetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_BidDetail_Edit)]
        private void Update(BidDetailInput BidDetailInput)
        {
            var BidDetailEntity = bidDetailRepository.GetAll()/*.Where(x => !x.IsDelete)*/.SingleOrDefault(x => x.Id == BidDetailInput.Id);
            if (BidDetailEntity == null)
            {
            }
            ObjectMapper.Map(BidDetailInput, BidDetailEntity);
            //SetAuditEdit(BidDetailEntity);
            bidDetailRepository.Update(BidDetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
