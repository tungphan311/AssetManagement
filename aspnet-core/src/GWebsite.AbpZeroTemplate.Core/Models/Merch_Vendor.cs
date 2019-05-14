using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using GSoft.AbpZeroTemplate;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Merch_Vendor: FullAuditModel
    {  

        public int MerchID { get; set; }
        public int VendorID { get; set; }
    }
}
