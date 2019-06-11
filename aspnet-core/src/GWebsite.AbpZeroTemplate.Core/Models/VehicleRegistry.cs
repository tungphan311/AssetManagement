using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class VehicleRegistry : FullAuditModel
    {
        public string PlateNumber { get; set; }
        public System.DateTime Date { get; set; } = System.DateTime.Now;
        public System.DateTime ExpirationDate { get; set; }
        public int RegisterNumber { get; set; }
        public int RegisterDuration { get; set; }
        public string RegisterUnit { get; set; }
        public string Note { get; set; }
    }
}