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
    public class Vendor: FullAuditModel
    {  
        public string Code { get; set; }

        public string Name { get; set; }

        public int TypeID { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string TIN { get; set; }

        public string PhoneNumber { get; set; }

        public string Contact { get; set; }

        public bool IsActive { get; set; }

        public string Note { get; set; }
    }
}
