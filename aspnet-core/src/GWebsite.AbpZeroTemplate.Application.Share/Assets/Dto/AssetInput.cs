using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// <model cref="Asset"></model>
    /// </summary>
    public class AssetInput : Entity<int>
    {
        public string nameAsset { get; set; }
        public int mountAsset { get; set;  }
<<<<<<< HEAD
        public bool? isRentOut { get; set; } = false;
        public decimal valueAsset { get; set; }
=======
        public int valueAsset { get; set; }
        public bool? isRentOut { get; set; } = false; 
>>>>>>> 1b39af43372e3632a1299669826a8996354131fa

    }
}
