using Abp.Application.Services;
using Abp.Authorization.Users;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Organizations;
using GSoft.AbpZeroTemplate.DonVi_s;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSoft.AbpZeroTemplate
{
    public class DonViAppService : AbpZeroTemplateAppServiceBase, IApplicationService
    {
        private readonly IRepository<TaiSan> _TaiSanRepository;
        private readonly IRepository<OrganizationUnit, long> _OrganizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> _UserOrganizationUnitRepository;

        public DonViAppService(
            IRepository<TaiSan> TaiSanRepository,
            IRepository<OrganizationUnit, long> OrganizationUnitRepository,
            IRepository<UserOrganizationUnit, long> UserOrganizationUnitRepository)
        {
            _TaiSanRepository = TaiSanRepository;
            _OrganizationUnitRepository = OrganizationUnitRepository;
            _UserOrganizationUnitRepository = UserOrganizationUnitRepository;
        }

        public List<UnitTaiSanDto> GetUnit()
        {
            long user_id = GetCurrentUser().Id;
            List<long> list_org_id = _UserOrganizationUnitRepository.GetAll().Where(p => p.UserId == user_id).Select(p => p.OrganizationUnitId).ToList();
            List<String> list_org_code = _OrganizationUnitRepository.GetAll().Where(p => list_org_id.Contains(p.Id)).Select(p => p.Code).ToList();

            List<UnitTaiSanDto> list_result = new List<UnitTaiSanDto>();
            HashSet<OrganizationUnit> set_org_all = new HashSet<OrganizationUnit>();
            foreach (string code in list_org_code)
                set_org_all.UnionWith(_OrganizationUnitRepository.GetAll().Where(p => p.Code.StartsWith(code)).ToList());

            foreach (OrganizationUnit org in set_org_all)
                list_result.Add(UnitTaiSanDtoMap(org));

            return list_result;
        }

        public List<UnitTaiSanDto> GetUnitCon(string unit_code)
        {
            List<OrganizationUnit> list_unit_con = _OrganizationUnitRepository.GetAll().Where(p => p.Code.StartsWith(unit_code)).ToList();
            List<UnitTaiSanDto> result = new List<UnitTaiSanDto>();
            foreach (OrganizationUnit unit in list_unit_con)
                result.Add(UnitTaiSanDtoMap(unit));
            return result; 
        }

        public bool UnitThemTaiSan(UnitThemTaiSanInput input)
        {
            if (_OrganizationUnitRepository.FirstOrDefault(b => b.Id == input.UnitId) != null)
            {
                _TaiSanRepository.Insert(new TaiSan { TenTaiSan = input.TenTaiSanThem, UnitId = input.UnitId });
                return true;
            }
            return false;
        }

        public bool UnitXuatTaiSan(UnitXuatTaiSanInput input)
        {
            var don_vi_nhan = _OrganizationUnitRepository.FirstOrDefault(b => b.Id == input.UnitNhanId);
            var don_vi_xuat = _OrganizationUnitRepository.FirstOrDefault(b => b.Id == input.UnitXuatId);
            TaiSan tai_san = _TaiSanRepository.FirstOrDefault(s => s.Id == input.TaiSanXuatId);

            if (don_vi_xuat == null || don_vi_nhan == null || tai_san == null)
                return false;
            else
            {
                tai_san.TrangThai = 1;
                tai_san.UnitId = don_vi_nhan.Id;
                _TaiSanRepository.Update(tai_san);
                return true;
            }
        }

        public List<TaiSanDto> TaiSanTheoTrangThai(long unit_id = -1, int trang_thai = 0)
        {
            List<TaiSanDto> result = new List<TaiSanDto>();
            var list_tai_san = _TaiSanRepository.GetAllList().Where(p => p.UnitId == unit_id && p.TrangThai == trang_thai);
            result = ObjectMapper.Map<List<TaiSanDto>>(list_tai_san);
            return result;
        }

        private UnitTaiSanDto UnitTaiSanDtoMap(OrganizationUnit unit)
        {
            UnitTaiSanDto dto = new UnitTaiSanDto();
            List<TaiSan> list_tai_san = _TaiSanRepository.GetAll().Where(p => p.UnitId == unit.Id).ToList();

            List<TaiSan> list_tai_san_con = new List<TaiSan>();
            List<OrganizationUnit> list_unit_con = _OrganizationUnitRepository.GetAll().Where(p => p.Code.StartsWith(unit.Code)).ToList();
            foreach (OrganizationUnit unit_con in list_unit_con)
                list_tai_san_con.AddRange(_TaiSanRepository.GetAll().Where(p => p.UnitId == unit_con.Id));

            dto.Id = unit.Id;
            dto.Code = unit.Code;
            dto.Name = unit.DisplayName;
            dto.TrongKho = list_tai_san.Where(p => p.TrangThai == 0).Count();
            dto.SuDung = list_tai_san_con.Where(p => p.TrangThai == 1).Count();
            dto.HuHong = list_tai_san.Where(p => p.TrangThai == 2).Count();
            return dto;
        }

    }
}