using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.POPayments.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.POPayments
{
    public interface IPOPaymentAppService
    {
        void CreateOrEditPOPayment(POPaymentInput popaymentInput);
        POPaymentInput GetPOPaymentForEdit(int id);
        void DeletePOPayment(int id);
        PagedResultDto<POPaymentDto> GetPOPayments(POPaymentFilter input);
    }
}
