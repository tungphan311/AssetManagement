using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts
{
    public interface IContractAppService
    {
        void CreateOrEditContract(ContractInput contractInput);
        ContractInput GetContractForEdit(int id);
        void DeleteContract(int id);
        PagedResultDto<ContractDto> GetContracts(ContractFilter input);
        ContractForViewDto GetContractForView(int id);
    }
}
