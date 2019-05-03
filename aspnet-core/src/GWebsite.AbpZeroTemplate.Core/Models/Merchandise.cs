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
    public class Merchandise: FullAuditModel
    {  
        public string Name { get; set; }

        public int TypeID { get; set; }

        public string Info { get; set; }

        public double Price { get; set; }
    }
}
