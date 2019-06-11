using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class VehicleInsurrance : FullAuditModel
    {
        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; } = System.DateTime.Now;
        public System.DateTime ExpirationDate { get; set; }
        public string Type { get; set; }
        public int InsurranceNumber { get; set; }
        public int InsurranceDuration { get; set; }
        public string InsurranceUnit { get; set; }
        public int MoneyAmount { get; set; }

    }
}
