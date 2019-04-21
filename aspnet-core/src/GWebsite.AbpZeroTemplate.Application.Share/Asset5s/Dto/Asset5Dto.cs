using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset5s.Dto
{
    /// <summary>
    /// <model cref="Asset5"></model>
    /// </summary>
    public class Asset5Dto : Entity<int>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Info { get; set; }
    }
}
