using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssignmentTables.Dto
{
    /// <summary>
    /// <model cref="AssignmentTable"></model>
    /// </summary>
    public class AssignmentTableDto : Entity<int>
    {
        public int MerchID { get; set; }
        public int VendorID { get; set; }
    }
}
