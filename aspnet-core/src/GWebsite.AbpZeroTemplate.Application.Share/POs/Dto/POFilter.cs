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
        public int POID { get; set; }

        public DateTime CreateDay { get; set; }

        public string OrderName { get; set; }

        public int ContractID { get; set; }

    }
}
