using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPaymentDetails
{
    public interface IContractPaymentDetailAppService
    {
        void CreateOrEditContractPaymentDetail(ContractPaymentDetailInput contractPaymentDetailInput);
        ContractPaymentDetailInput GetContractPaymentDetailForEdit(int id);
        void DeleteContractPaymentDetail(int id);
        void DeleteMultiContractPaymentDetail(int contractId);
        PagedResultDto<ContractPaymentDetailDto> GetContractPaymentDetails(ContractPaymentDetailFilter input);
        ContractPaymentDetailForViewDto GetContractPaymentDetailForView(int id);
    }
}
