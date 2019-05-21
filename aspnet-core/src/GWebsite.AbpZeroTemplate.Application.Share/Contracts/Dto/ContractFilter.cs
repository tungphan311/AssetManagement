using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto
{
    /// <summary>
    /// <model cref="Contract"></model>
    /// </summary>
    public class ContractFilter : PagedAndSortedInputDto
    {
        public string ContractID { get; set; }
        public string Name { get; set; }
        //public DateTime DeliveryTime { get; set; }
        public int BriefcaseID { get; set; }
        public int VendorID { get; set; }
       
    }     
}
