using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices
{
    public interface IAttachedDeviceAppService
    {
        void CreateOrEditAttachedDevice(AttachedDeviceInput attachedDeviceInput);
        AttachedDeviceInput GetAttachedDeviceForEdit(int id);
        void DeleteAttachedDevice(int id);
        PagedResultDto<AttachedDeviceDto> GetAttachedDevices(AttachedDeviceFilter input);
        AttachedDeviceForViewDto GetAttachedDeviceForView(int id);
    }
}