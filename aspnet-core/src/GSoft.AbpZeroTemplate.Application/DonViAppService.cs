using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using GSoft.AbpZeroTemplate.DonVi_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate
{
    public class DonViAppService : AbpZeroTemplateAppServiceBase, IApplicationService
    {
        private readonly IRepository<DonVi> _DonViRepository;

        public DonViAppService(IRepository<DonVi> DonViRepository)
        {
            _DonViRepository = DonViRepository;
        }

        public List<DonViDto> GetDonVi(GetDonViInput input)
        {
            var people = _DonViRepository
                .GetAll()
                .WhereIf(!input.Filter.IsNullOrEmpty(), p => p.TenDonVi.ToLower().Equals(input.Filter.ToLower()))
                .ToList();

            return ObjectMapper.Map<List<DonViDto>>(people);
        }

        public DonViDto ThemTaiSanVaoDonVi(DonViThemTaiSanInput input)
        {

            var result = _DonViRepository.Single(b => b.TenDonVi == input.TenDonVi);
            if (result != null)
            {
                result.TaiSanTrongKho += input.TaiSanThem;
                _DonViRepository.Update(result);
            }

            return ObjectMapper.Map<DonViDto>(result);

        }

        public bool DonViXuatTaiSan(DonViXuatTaiSanInput input)
        {

            var don_vi_xuat = _DonViRepository.Single(b => b.TenDonVi == input.DonViXuat);
            var don_vi_nhan = _DonViRepository.Single(b => b.TenDonVi == input.DonViNhan);

            if (don_vi_xuat == null || don_vi_nhan == null)
                return false;
            else if (don_vi_xuat.TaiSanTrongKho - input.SoLuong < 0)
                return false;
            else
            {
                don_vi_xuat.TaiSanTrongKho -= input.SoLuong;
                don_vi_xuat.TaiSanSuDung += input.SoLuong;
                don_vi_nhan.TaiSanSuDung += input.SoLuong;
                _DonViRepository.Update(don_vi_xuat);
                _DonViRepository.Update(don_vi_nhan);
                return true;
            }
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
