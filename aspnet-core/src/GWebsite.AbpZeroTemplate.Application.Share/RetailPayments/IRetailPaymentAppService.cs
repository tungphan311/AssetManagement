using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RetailPayments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RetailPayments
{
    public interface IRetailPaymentAppService
    {
        void CreateOrEditRetailPayment(RetailPaymentInput retailPaymentInput);
        RetailPaymentInput GetRetailPaymentForEdit(int id);
        void DeleteRetailPayment(int id);
        PagedResultDto<RetailPaymentDto> GetRetailPayments(RetailPaymentFilter input);
        RetailPaymentForViewDto GetRetailPaymentForView(int id);
    }
}
