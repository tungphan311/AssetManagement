using GSoft.AbpZeroTemplate.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Migrations.Seed.Host
{
    public class MerchandiseInit
    {
        public readonly AbpZeroTemplateDbContext _context;

        public MerchandiseInit(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var ban = _context.Merchandises.FirstOrDefault(p => p.Name == "Bàn Hoà Phát");
            if (ban == null)
            {
                _context.Merchandises.Add(
                    new Merchandise
                    {
                        Name = "Bàn Hoà Phát",
                        TypeID = 1,
                        Info = "Bàn làm việc cao cấp",
                        Price = 1500000
                    });
            }

            var ghe = _context.Merchandises.FirstOrDefault(p => p.Name == "Ghế Hoà Phát");
            if (ghe == null)
            {
                _context.Merchandises.Add(
                    new Merchandise
                    {
                        Name = "Ghế Hoà Phát",
                        TypeID = 2,
                        Info = "Ghế da cao cấp",
                        Price = 1000000
                    });
            }
        }
    }
}
