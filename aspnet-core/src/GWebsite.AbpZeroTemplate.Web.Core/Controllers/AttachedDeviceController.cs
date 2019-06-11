using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices;
using GWebsite.AbpZeroTemplate.Application.Share.AttachedDevices.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AttachedDeviceController : GWebsiteControllerBase
    {
        private readonly IAttachedDeviceAppService attachedDeviceAppService;

        public AttachedDeviceController(IAttachedDeviceAppService attachedDeviceAppService)
        {
            this.attachedDeviceAppService = attachedDeviceAppService;
        }

        [HttpGet]
        public PagedResultDto<AttachedDeviceDto> GetAttachedDevicesByFilter(AttachedDeviceFilter attachedDeviceFilter)
        {
            return attachedDeviceAppService.GetAttachedDevices(attachedDeviceFilter);
        }

        [HttpGet]
        public AttachedDeviceInput GetAttachedDeviceForEdit(int id)
        {
            return attachedDeviceAppService.GetAttachedDeviceForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAttachedDevice([FromBody] AttachedDeviceInput input)
        {
            attachedDeviceAppService.CreateOrEditAttachedDevice(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAttachedDevice(int id)
        {
            attachedDeviceAppService.DeleteAttachedDevice(id);
        }

        [HttpGet]
        public AttachedDeviceForViewDto GetAttachedDeviceForView(int id)
        {
            return attachedDeviceAppService.GetAttachedDeviceForView(id);
        }
    }
}