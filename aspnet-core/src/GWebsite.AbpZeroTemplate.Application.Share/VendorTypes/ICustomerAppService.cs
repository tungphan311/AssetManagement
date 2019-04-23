using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.VendorTypes.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.VendorTypes
{
    public interface IVendorTypeAppService
    {
        void CreateOrEditVendorType(VendorTypeInput customerInput);
        VendorTypeInput GetVendorTypeForEdit(int id);
        void DeleteVendorType(int id);
        PagedResultDto<VendorTypeDto> GetVendorTypes(VendorTypeFilter input);
        VendorTypeForViewDto GetVendorTypeForView(int id);
    }
}
