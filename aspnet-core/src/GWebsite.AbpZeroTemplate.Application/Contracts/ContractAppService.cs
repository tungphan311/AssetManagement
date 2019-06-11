using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Contracts
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class ContractAppService : GWebsiteAppServiceBase, IContractAppService
    {
        private readonly IRepository<Contract> contractRepository;
        private readonly IRepository<ContractDetail> detailRepository;
        private readonly IRepository<ContractPayment> paymentRepository;

        public ContractAppService(IRepository<Contract> contractRepository, IRepository<ContractDetail> detailRepository, IRepository<ContractPayment> paymentRepository)
        {
            this.contractRepository = contractRepository;
            this.detailRepository = detailRepository;
            this.paymentRepository = paymentRepository;
        }

        #region Public Method

        public void CreateOrEditContract(ContractInput contractInput)
        {
            if (contractInput.Id == 0)
            {
                Create(contractInput);
            }
            else
            {
                Update(contractInput);
            }
        }

        public void DeleteContract(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity != null)
            {
                contractEntity.IsDelete = true;
                contractRepository.Update(contractEntity);

                // xoá ContractDetail ứng với contract này
                var detailList = detailRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.ContractID == id);
                foreach(var detail in detailList)
                {
                    detail.IsDelete = true;
                    SetAuditEdit(detail);
                    detailRepository.Update(detail);
                }

                // xoá contract payment ứng với contract này
                var paymentList = paymentRepository.GetAll().Where(x => !x.IsDelete && x.ContractID == id);
                foreach(var payment in paymentList)
                {
                    payment.IsDelete = true;
                    SetAuditEdit(payment);
                    paymentRepository.Update(payment);
                }

                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractInput GetContractForEdit(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity == null)
            {
                return null;
            }

            var contractInput = ObjectMapper.Map<ContractInput>(contractEntity);
            var detailList = detailRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.ContractID == id);
            contractInput.Products = detailList.Select(x => ObjectMapper.Map<ContractDetailInput>(x)).ToList();

            var paymentList = paymentRepository.GetAll().Where(x => !x.IsDelete && x.ContractID == id);
            contractInput.Payments = paymentList.Select(x => ObjectMapper.Map<ContractPaymentInput>(x)).ToList();

            return contractInput;
        }

        public ContractForViewDto GetContractForView(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractForViewDto>(contractEntity);
        }

        public PagedResultDto<ContractDto> GetContracts(ContractFilter input)
        {
            var query = contractRepository.GetAll().Where(x => !x.IsDelete);

            // filter by Id
            if (input.ContractID != null)
            {
                query = query.Where(x => x.ContractID.ToLower().Contains(input.ContractID.ToLower()));
            }

            //filter by name 
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name.ToLower()));
            }

            if (input.DeliveryTime != null)
            {
                DateTime dt = DateTime.ParseExact(input.DeliveryTime, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                dt = dt.ToUniversalTime();
                query = query.Where(x => x.DeliveryTime.DayOfYear == dt.DayOfYear);

            }

            // filter by BriefcaseID
            if (input.BriefcaseID != 0)
            {
                query = query.Where(x => x.BriefcaseID == input.BriefcaseID);
            }

            // filter by VendorID
            if (input.VendorID != 0)
            {
                query = query.Where(x => x.VendorID == input.VendorID);
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ContractDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(ContractInput contractInput)
        {
            var contractEntity = ObjectMapper.Map<Contract>(contractInput);
            SetAuditInsert(contractEntity);
            var id = contractRepository.InsertAndGetId(contractEntity);

            foreach (var product in contractInput.Products)
            {
                // insert vo bang ProductContract co productId va contractId
                product.ContractID = id;
                var detailEntity = ObjectMapper.Map<ContractDetail>(product);
                SetAuditInsert(detailEntity);
                detailRepository.Insert(detailEntity);
            }

            foreach (var payment in contractInput.Payments)
            {
                payment.ContractID = id;
                var paymentEntity = ObjectMapper.Map<ContractPayment>(payment);
                SetAuditInsert(paymentEntity);
                paymentRepository.Insert(paymentEntity);
            }

            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(ContractInput contractInput)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == contractInput.Id);
            if (contractEntity == null)
            {
            }
            ObjectMapper.Map(contractInput, contractEntity);
            SetAuditEdit(contractEntity);
            contractRepository.Update(contractEntity);

            if (contractInput.Products == null)
            {
                // nếu input rỗng thì xoá hết detail đang có của contract
                var detailList = detailRepository.GetAll().Where(x => x.ContractID == contractInput.Id);

                foreach (var detail in detailList)
                {
                    detail.IsDelete = true;
                    SetAuditEdit(detail);
                    detailRepository.Update(detail);
                }
            }
            else
            {
                // update list contract detail
                var detailList = detailRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.ContractID == contractInput.Id);

                foreach (var detail in detailList)
                {
                    if (!(contractInput.Products.Exists(x => x.MerchID == detail.MerchID)))
                    {
                        // nếu không tại trong list input thì xoá đi
                        detail.IsDelete = true;
                        SetAuditEdit(detail);
                        detailRepository.Update(detail);
                    }
                }

                // update contract detail
                foreach (var product in contractInput.Products)
                {
                    var detailEntity = detailList.SingleOrDefault(x => x.MerchID == product.MerchID);
                    if (detailEntity == null)
                    {
                        // nếu chưa tồn tại thì thêm 
                        detailEntity = ObjectMapper.Map<ContractDetail>(product);
                        detailEntity.ContractID = contractEntity.Id;
                        SetAuditInsert(detailEntity);
                        detailRepository.Insert(detailEntity);
                    }
                    else
                    {
                        // nếu có thì sẽ update
                        product.ContractID = detailEntity.Id;
                        ObjectMapper.Map(product, detailEntity);
                        detailEntity.ContractID = contractEntity.Id;
                        SetAuditEdit(detailEntity);
                        detailRepository.Update(detailEntity);
                    }
                }
            }

            // xoá hết payment đang có trước 
            var paymentList = paymentRepository.GetAll().Where(x => !x.IsDelete && x.ContractID == contractInput.Id);

            foreach (var payment in paymentList)
            {
                payment.IsDelete = true;
                SetAuditEdit(payment);
                paymentRepository.Update(payment);
            }

            if (contractInput.Payments != null)
            {
                foreach(var payment in contractInput.Payments)
                {
                    payment.ContractID = contractInput.Id;
                    var paymentEntity = ObjectMapper.Map<ContractPayment>(payment);
                    SetAuditInsert(paymentEntity);
                    paymentRepository.Insert(paymentEntity);
                }
            }
 
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}