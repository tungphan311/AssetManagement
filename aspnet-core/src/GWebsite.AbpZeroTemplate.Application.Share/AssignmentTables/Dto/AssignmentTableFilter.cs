using GSoft.AbpZeroTemplate.Dto;
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
    public class AssignmentTableFilter : PagedAndSortedInputDto
    {
        public int MerchID { get; set; }
        public int VendorID { get; set; }
    }
}
