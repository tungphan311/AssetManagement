using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Bids
{
    public class BidAppService : GWebsiteAppServiceBase, IBidAppService
    {
        private readonly IRepository<Bid> bidRepository;
        private readonly IRepository<BidDetail> bidDetailRepository;
        private readonly IRepository<Project> projectRepository;
        private readonly IRepository<Provider> providerRepository;
        public BidAppService(IRepository<Bid> bidRepository, IRepository<BidDetail> bidDetailRepository, IRepository<Project> projectRepository)
        {
            this.bidRepository = bidRepository;
            this.bidDetailRepository = bidDetailRepository;
            this.projectRepository = projectRepository;
            this.providerRepository = providerRepository;
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
            var BidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BidEntity != null)
            {
                BidEntity.IsDelete = true;
                bidRepository.Update(BidEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BidInput GetBidForEdit(int id)
        {
            var bidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (bidEntity == null)
            {
                return null;
            }

            var result = ObjectMapper.Map<BidInput>(bidEntity);

            if (result.ProjectId == null)
            {
                result.Project = new Application.Share.Projects.Dto.ProjectInput();
            }
            else
            {
                result.Project = ObjectMapper.Map<ProjectInput>(this.projectRepository.FirstOrDefault(x => x.Id == result.ProjectId));
            }

            var details = ObjectMapper.Map<List<BidDetailInput>>(bidDetailRepository.GetAll().Where(x => x.BidId == id).ToList());
            if (details != null && details.Count() > 0)
            {
                for (int i = 0; i < details.Count(); i++)
                {
                    var provider = ObjectMapper.Map<ProviderInput>(providerRepository.FirstOrDefault(x => x.Id == details.ElementAt(i).ProviderId && x.IsDelete == false));
                    if (provider == null) provider = new ProviderInput();
                    details.ElementAt(i).Provider = provider;
                }
            }

            result.BidDetails = details;

            return ObjectMapper.Map<BidInput>(bidEntity);
        }

        public BidForViewDto GetBidForView(int id)
        {
            try
            {
                var BidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
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
            var query = bidRepository.GetAll().Where(x => !x.IsDelete);

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
        private void Create(BidInput bidInput)
        {
            System.Console.WriteLine("BidInput: " + bidInput.Code.ToString());
            try
            {
                var bidEntity = ObjectMapper.Map<Bid>(bidInput);
                if (bidEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(bidEntity);
                var bidId = bidRepository.InsertAndGetId(bidEntity);
                if (bidInput.BidDetails != null && bidInput.BidDetails.Count() > 0)
                {
                    foreach (var item in bidInput.BidDetails)
                    {
                        var bidDetailObject = ObjectMapper.Map<BidDetail>(item);
                        bidDetailObject.BidId = bidId;
                        bidDetailRepository.Insert(bidDetailObject);
                    }
                }


                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex);
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Bid_Edit)]
        private void Update(BidInput bidInput)
        {
            var bidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == bidInput.Id);
            if (bidEntity == null)
            {

            }
            ObjectMapper.Map(bidInput, bidEntity);
            SetAuditEdit(bidEntity);
            bidRepository.Update(bidEntity);

            bidDetailRepository.Delete(x => x.BidId == bidInput.Id);
            if (bidInput.BidDetails != null && bidInput.BidDetails.Count() > 0)
            {
                foreach (var item in bidInput.BidDetails)
                {
                    var bidDetailObject = ObjectMapper.Map<BidDetail>(item);
                    bidDetailObject.BidId = bidInput.Id;
                    bidDetailRepository.Insert(bidDetailObject);
                }
            }

            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
