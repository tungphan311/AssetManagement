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
    public class BidInput : Entity<int>
    {
        public BidInput()
        {
            BidDetails = new List<BidDetailInput>();
            Project = new ProjectInput();
        }
        public string Code { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Status Status { get; set; }
        public BiddingForm BiddingForm { get; set; }

        public decimal CautionMoney { get; set; }
        public string AttachmentFile { get; set; }
        public int? ProjectId { get; set; }
        public ProjectInput Project { get; set; }

        public List<BidDetailInput> BidDetails { get; set; }
    }
}
