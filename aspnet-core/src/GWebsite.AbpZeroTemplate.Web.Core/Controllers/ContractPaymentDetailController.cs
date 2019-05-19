using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractPaymentDetailController : GWebsiteControllerBase
    {
        private readonly IContractPaymentDetailAppService contractPaymentDetailAppService;

        public ContractPaymentDetailController(IContractPaymentDetailAppService contractPaymentDetailAppService)
        {
            this.contractPaymentDetailAppService = contractPaymentDetailAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractPaymentDetailDto> GetContractPaymentDetailsByFilter(ContractPaymentDetailFilter ContractPaymentDetailFilter)
        {
            return contractPaymentDetailAppService.GetContractPaymentDetails(ContractPaymentDetailFilter);
        }

        [HttpGet]
        public ContractPaymentDetailInput GetContractPaymentDetailForEdit(int id)
        {
            return contractPaymentDetailAppService.GetContractPaymentDetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditContractPaymentDetail([FromBody] ContractPaymentDetailInput input)
        {
            contractPaymentDetailAppService.CreateOrEditContractPaymentDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContractPaymentDetail(int id)
        {
            contractPaymentDetailAppService.DeleteContractPaymentDetail(id);
        }
        [HttpDelete("{contractId}")]
        public void DeleteMultiContractPaymentDetail(int contractId)
        {
            contractPaymentDetailAppService.DeleteMultiContractPaymentDetail(contractId);
        }

        [HttpGet]
        public ContractPaymentDetailForViewDto GetContractPaymentDetailForView(int id)
        {
            return contractPaymentDetailAppService.GetContractPaymentDetailForView(id);
        }
    }
}
