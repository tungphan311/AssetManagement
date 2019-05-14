using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
   public class AssetForView : Entity
    {
        public string nameAsset { get; set; }
        public int mountAsset { get; set;  }
<<<<<<< HEAD
        public bool isRentOut { get; set;  }
=======
        public int valueAsset { get; set; }
>>>>>>> 1b39af43372e3632a1299669826a8996354131fa
    }

}
