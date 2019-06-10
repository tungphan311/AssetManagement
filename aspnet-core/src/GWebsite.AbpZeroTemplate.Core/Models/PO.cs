using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class PO: FullAuditModel
    {
        public int ReportID { get; set; }               // so to trinh

        public DateTime ReceiveReportDay { get; set; }  // ngay nhan to trinh    

        public DateTime ApproveReportDay { get; set; }  // ngay duyet to trinh

        public string POID { get; set; }                // so PO

        public DateTime CreateDay { get; set; }         // ngay lap PO

        public string OrderName { get; set; }           // ten don hang

        public int ContractID { get; set; }             // so hop dong

        public int VendorID { get; set; }               // ma NCC
    }
}
