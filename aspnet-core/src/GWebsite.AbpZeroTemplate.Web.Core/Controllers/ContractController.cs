using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractController : GWebsiteControllerBase
    {
        private readonly IContractAppService contractAppService;

        public ContractController(IContractAppService contractAppService)
        {
            this.contractAppService = contractAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractDto> GetContractsByFilter(ContractFilter contractFilter)
        {
            return contractAppService.GetContracts(contractFilter);
        }

        [HttpGet]
        public ContractInput GetContractForEdit(int id)
        {
            return contractAppService.GetContractForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditContract([FromBody] ContractInput input)
        {
            contractAppService.CreateOrEditContract(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContract(int id)
        {
            contractAppService.DeleteContract(id);
        }

        [HttpGet]
        public ContractForViewDto GetContractForView(int id)
        {
            return contractAppService.GetContractForView(id);
        }
    }
}