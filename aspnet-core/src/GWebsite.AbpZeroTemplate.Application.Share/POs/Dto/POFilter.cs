using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.POs.Dto
{
    public class POFilter: PagedAndSortedInputDto
    {
        public string POID { get; set; }

        public string OrderName { get; set; }

        public string ContractID { get; set; }

        public string VendorID { get; set; }

        public string Type { get; set; }
    }
}
