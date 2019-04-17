using System.Linq;
using GSoft.AbpZeroTemplate.EntityFrameworkCore;

namespace GSoft.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialDonViCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialDonViCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var don_vi_chinh = _context.DonVi.FirstOrDefault(p => p.TenDonVi == "DonViChinh");
            if (don_vi_chinh == null)
            {
                _context.DonVi.Add(
                    new DonVi
                    {
                        TenDonVi = "DonViChinh",
                        TaiSanSuDung = 9,
                        TaiSanHu = 0,
                        TaiSanTrongKho = 1
                    });
            }

            var don_vi_con1 = _context.DonVi.FirstOrDefault(p => p.TenDonVi == "DonVi1");
            if (don_vi_con1 == null)
            {
                _context.DonVi.Add(
                    new DonVi
                    {
                        TenDonVi = "DonVi1",
                        TaiSanSuDung = 2,
                        TaiSanHu = 0,
                        TaiSanTrongKho = 0,
                        DonViChinh = "DonViChinh"
                    });
            }

            var don_vi_con2 = _context.DonVi.FirstOrDefault(p => p.TenDonVi == "DonVi2");
            if (don_vi_con2 == null)
            {
                _context.DonVi.Add(
                    new DonVi
                    {
                        TenDonVi = "DonVi2",
                        TaiSanSuDung = 3,
                        TaiSanHu = 0,
                        TaiSanTrongKho = 0,
                        DonViChinh = "DonViChinh"
                    });
            }

            var don_vi_con3 = _context.DonVi.FirstOrDefault(p => p.TenDonVi == "DonVi3");
            if (don_vi_con3 == null)
            {
                _context.DonVi.Add(
                    new DonVi
                    {
                        TenDonVi = "DonVi3",
                        TaiSanSuDung = 4,
                        TaiSanHu = 0,
                        TaiSanTrongKho = 0,
                        DonViChinh = "DonViChinh"
                    });
            }
        }
    }
}
