using Abp.Application.Services;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using GSoft.AbpZeroTemplate.DonVi_s;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSoft.AbpZeroTemplate
{
    public class DonViAppService : AbpZeroTemplateAppServiceBase, IApplicationService
    {
        private readonly IRepository<DonVi> _DonViRepository;
        private readonly IRepository<TaiSan> _TaiSanRepository;

        public DonViAppService(IRepository<DonVi> DonViRepository, IRepository<TaiSan> TaiSanRepository)
        {
            _DonViRepository = DonViRepository;
            _TaiSanRepository = TaiSanRepository;
        }

        public List<DonViDto> GetDonVi(GetDonViInput input)
        {
            var list_don_vi = _DonViRepository.GetAll()
                .WhereIf(!input.Filter.IsNullOrEmpty(), p => p.TenDonVi.ToLower().Equals(input.Filter.ToLower()))
                .ToList();

            List<DonViDto> result = new List<DonViDto>();
            foreach (DonVi don_vi in list_don_vi)
                result.Add(MapDonViToDTO(don_vi));
            return result;
        }

        public List<DonViDto> GetDonViCon(int don_vi_id = -1)
        {
            var list_don_vi = _DonViRepository.GetAll().Where(p => p.DonViChinhId == don_vi_id).ToList();
            List<DonViDto> result = new List<DonViDto>();
            foreach (DonVi don_vi in list_don_vi)
                result.Add(MapDonViToDTO(don_vi));
            return result;
        }

        public bool DonViThemTaiSan(DonViThemTaiSanInput input)
        {
            if (_DonViRepository.FirstOrDefault(b => b.Id == input.DonViId) != null)
            {
                _TaiSanRepository.Insert(new TaiSan { TenTaiSan = input.TenTaiSanThem, DangTrongKho = input.DonViId });
                return true;
            }
            return false;
        }

        public bool DonViXuatTaiSan(DonViXuatTaiSanInput input)
        {
            var don_vi_nhan = _DonViRepository.FirstOrDefault(b => b.Id == input.DonViNhanId);
            var don_vi_xuat = _DonViRepository.FirstOrDefault(b => b.Id == input.DonViXuatId);
            TaiSan tai_san = _TaiSanRepository.FirstOrDefault(s => s.Id == input.TaiSanXuatId);

            if (don_vi_xuat == null || don_vi_nhan == null || tai_san == null)
                return false;
            else
            {
                tai_san.DangTrongKho = 0;
                tai_san.DangSuDung = don_vi_nhan.Id;
                _TaiSanRepository.Update(tai_san);
                return true;
            }
        }

        public List<TaiSanDto> TaiSanTrongKho(int id_don_vi = -1)
        {
            List<TaiSanDto> result = new List<TaiSanDto>();
            var list_tai_san = _TaiSanRepository.GetAllList().Where(p => p.DangTrongKho == id_don_vi);
            result = ObjectMapper.Map<List<TaiSanDto>>(list_tai_san);
            return result;
        }

        public List<TaiSanDto> TaiSanSuDung(int id_don_vi = -1)
        {
            List<TaiSanDto> result = new List<TaiSanDto>();
            var list_tai_san = _TaiSanRepository.GetAllList().Where(p => p.DangSuDung == id_don_vi);
            result = ObjectMapper.Map<List<TaiSanDto>>(list_tai_san);
            return result;
        }

        public List<TaiSanDto> TaiSanHuHong(int id_don_vi = -1)
        {
            List<TaiSanDto> result = new List<TaiSanDto>();
            var list_tai_san = _TaiSanRepository.GetAllList().Where(p => p.BiHuHong == id_don_vi);
            result = ObjectMapper.Map<List<TaiSanDto>>(list_tai_san);
            return result;
        }

        private int TinhSoTaiSanCuaDonVi(DonVi don_vi)
        {
            int result = 0;
            result += _TaiSanRepository.GetAll().Where(p => p.DangSuDung == don_vi.Id).ToList().Count();
            var list_don_vi_con = _DonViRepository.GetAll().Where(p => p.DonViChinhId == don_vi.Id).ToList();
            foreach (DonVi don_vi_con in list_don_vi_con)
                    result += TinhSoTaiSanCuaDonVi(don_vi_con);
            return result;
        }

        private DonViDto MapDonViToDTO(DonVi don_vi)
        {
            DonViDto dv_dto = new DonViDto();
            dv_dto.Id = don_vi.Id;
            dv_dto.TenDonVi = don_vi.TenDonVi;
            try
            {
                dv_dto.DonViChinh = _DonViRepository.FirstOrDefault(p => p.Id == don_vi.DonViChinhId).TenDonVi;
                dv_dto.DonViChinhId = don_vi.DonViChinhId;
            } catch (Exception) { }
            dv_dto.TaiSanSuDung = TinhSoTaiSanCuaDonVi(don_vi);
            dv_dto.TaiSanTrongKho = _TaiSanRepository.GetAll().Where(p => p.DangTrongKho == don_vi.Id).Count();
            return dv_dto;
        }

        //public async Task DeleteDonVi(EntityDto input)
        //{
        //    await _DonViRepository.DeleteAsync(input.Id);
        //}

        //public async Task CreateDonVi(CreateDonViInput input)
        //{
        //    //var person = ObjectMapper.Map<Person>(input);
        //    //await _DonViRepository.InsertAsync(person);
        //}

    }
}