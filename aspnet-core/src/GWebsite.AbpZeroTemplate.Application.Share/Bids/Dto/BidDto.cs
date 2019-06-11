using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Application.Share.BidDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Core.Models.Enums;
using GWebsite.AbpZeroTemplate.Core.Models.Enums.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto
{
    public class BidDto : Entity<int>
    {
        public BidDto()
        {
            BidDetails = new List<BidDetailDto>();
            Project = new ProjectDto();
        }
        public string Code { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Status Status { get; set; }
        public BiddingForm BiddingForm { get; set; }

        public decimal CautionMoney { get; set; }
        public string AttachmentFile { get; set; }
        public int? ProjectId { get; set; }
        public ProjectDto Project { get; set; }

        public List<BidDetailDto> BidDetails { get; set; }
    }
}
