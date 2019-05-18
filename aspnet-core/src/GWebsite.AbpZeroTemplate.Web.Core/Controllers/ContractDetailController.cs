using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractDetailController : GWebsiteControllerBase
    {
        private readonly IContractDetailAppService contractdetailAppService;

        public ContractDetailController(IContractDetailAppService contractdetailAppService)
        {
            this.contractdetailAppService = contractdetailAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractDetailDto> GetContractDetailsByFilter(ContractDetailFilter contractdetailFilter)
        {
            return contractdetailAppService.GetContractDetails(contractdetailFilter);
        }

        [HttpGet]
        public ContractDetailInput GetContractDetailForEdit(int id)
        {
            return contractdetailAppService.GetContractDetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditContractDetail([FromBody] ContractDetailInput input)
        {
            contractdetailAppService.CreateOrEditContractDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContractDetail(int id)
        {
            contractdetailAppService.DeleteContractDetail(id);
        }
    }
}