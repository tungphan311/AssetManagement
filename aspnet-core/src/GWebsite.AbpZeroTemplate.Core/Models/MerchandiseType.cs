﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class MerchandiseType: FullAuditModel
    {
        public string TypeID { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public string Note { get; set; }
    }
}
