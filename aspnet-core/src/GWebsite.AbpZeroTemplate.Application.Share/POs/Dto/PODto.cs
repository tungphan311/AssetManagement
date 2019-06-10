using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.POs.Dto
{
    public class PODto: Entity<int>
    {
        public int ReportID { get; set; }

        public DateTime ReceiveReportDay { get; set; }

        public DateTime ApproveReportDay { get; set; }

        public string POID { get; set; }

        public DateTime CreateDay { get; set; }

        public string OrderName { get; set; }

        public int ContractID { get; set; }

        public int VendorID { get; set; }
    }
}
