using GSoft.AbpZeroTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merchandise.Dto
{
    public class CreateMerchandiseInput
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual int TypeID { get; set; }

        [Required]
        public virtual string Info { get; set; }

        [Required]
        public virtual double Price { get; set; }
    }
}
