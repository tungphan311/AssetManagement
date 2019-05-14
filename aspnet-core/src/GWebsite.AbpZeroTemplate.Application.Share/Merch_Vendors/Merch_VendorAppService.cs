using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Merch_Vendors
{
    public interface IMerch_VendorAppService
    {
        void CreateOrEditMerch_Vendor(Merch_VendorInput customerInput);
        Merch_VendorInput GetMerch_VendorForEdit(int id);
        void DeleteMerch_Vendor(int id);
        PagedResultDto<Merch_VendorDto> GetMerch_Vendors(Merch_VendorFilter input);
    }
}
