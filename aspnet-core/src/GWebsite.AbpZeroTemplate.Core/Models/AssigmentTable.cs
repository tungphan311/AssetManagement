using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssignmentTable : FullAuditModel
    {
        public int MerchID { get; set; }
        public int VendorID { get; set; }
    }
}
