using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vendors.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vendors
{
    public interface IVendorAppService
    {
        void CreateOrEditVendor(VendorInput customerInput);
        VendorInput GetVendorForEdit(int id);
        void DeleteVendor(int id);
        PagedResultDto<VendorDto> GetVendors(VendorFilter input);
        VendorForViewDto GetVendorForView(int id);
    }
}
