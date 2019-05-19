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
                _context.DonVi.Add(new DonVi { TenDonVi = "DonViChinh", });
                don_vi_chinh = _context.DonVi.FirstOrDefault(p => p.TenDonVi == "DonViChinh");
            }

            var don_vi_con = _context.DonVi.FirstOrDefault(p => p.TenDonVi == "DonVi1");
            if (don_vi_con == null)
            {
                _context.DonVi.Add(new DonVi { TenDonVi = "DonVi1", DonViChinhId = don_vi_chinh.Id});
            }

            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Kệ sách") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Kệ sách", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Ghế xoay") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Ghế xoay", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Tủ hồ sơ") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Tủ hồ sơ", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Bảng lật") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Bảng lật", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Quạt đứng") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Quạt đứng", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Thùng nước") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Thùng nước", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Phòng ngăn") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Phòng ngăn", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Máy điều hòa") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Máy điều hòa", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Bàn làm việc") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Bàn làm việc", });
            //if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Xe vận chuyển") == null)
            //    _context.TaiSan.Add(new TaiSan { TenTaiSan = "Xe vận chuyển", });

            //void Ini_TaiSan_VaoDB(AbpZeroTemplateDbContext context, string ten_tai_san, DonVi don_vi)
            //{
            //    if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == ten_tai_san) == null)
            //        _context.TaiSan.Add(new TaiSan { TenTaiSan = ten_tai_san, });
            //    else
            //        don_vi.TaiSanTrongKho.Add(_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == ten_tai_san));
            //}

            //if (don_vi_chinh != null)
            //{
            //        don_vi_chinh.TaiSanSuDung.Clear();
            //Ini_TaiSan_VaoDB(_context, "Kệ sách", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Ghế xoay", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Tủ hồ sơ", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Bảng lật", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Quạt đứng", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Thùng nước", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Phòng ngăn", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Máy điều hòa", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Bàn làm việc", don_vi_chinh);
            //Ini_TaiSan_VaoDB(_context, "Xe vận chuyển", don_vi_chinh);
            //    _context.DonVi.Update(don_vi_chinh);

            //}
        }

        //private void Ini_TaiSan_VaoDB(AbpZeroTemplateDbContext context, string ten_tai_san, DonVi don_vi)
        //{
        //    if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == ten_tai_san) == null)
        //    {
        //        _context.TaiSan.Add(new TaiSan { TenTaiSan = ten_tai_san, });
        //        don_vi.TaiSanTrongKho.Add(_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == ten_tai_san));
        //    }
        //}
    }
}
