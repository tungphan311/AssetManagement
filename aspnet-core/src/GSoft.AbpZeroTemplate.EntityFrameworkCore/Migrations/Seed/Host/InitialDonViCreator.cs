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

            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Kệ sách") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Kệ sách", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Ghế xoay") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Ghế xoay", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Tủ hồ sơ") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Tủ hồ sơ", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Bảng lật") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Bảng lật", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Quạt đứng") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Quạt đứng", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Thùng nước") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Thùng nước", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Phòng ngăn") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Phòng ngăn", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Máy điều hòa") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Máy điều hòa", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Bàn làm việc") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Bàn làm việc", });
            if (_context.TaiSan.FirstOrDefault(p => p.TenTaiSan == "Xe vận chuyển") == null)
                _context.TaiSan.Add(new TaiSan { TenTaiSan = "Xe vận chuyển", });
        }

    }
}
