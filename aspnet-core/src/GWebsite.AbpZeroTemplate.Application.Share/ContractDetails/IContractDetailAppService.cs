using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractDetails
{
    public interface IContractDetailAppService
    {
        void CreateOrEditContractDetail(ContractDetailInput contractdetailInput);
        ContractDetailInput GetContractDetailForEdit(int id);
        void DeleteContractDetail(int id);
        PagedResultDto<ContractDetailDto> GetContractDetails(ContractDetailFilter input);
    }
}
