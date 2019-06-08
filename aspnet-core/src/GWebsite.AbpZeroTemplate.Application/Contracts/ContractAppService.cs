using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractDetails.Dto;
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

        public ContractAppService(IRepository<Contract> contractRepository, IRepository<ContractDetail> detailRepository)
        {
            this.contractRepository = contractRepository;
            this.detailRepository = detailRepository;
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

                foreach(var detail in detailList)
                {
                    detail.IsDelete = true;
                    SetAuditEdit(detail);
                    detailRepository.Update(detail);
                }
                return;
            }
            else
            {
                // update list contract detail
                var detailList = detailRepository.GetAll().Where(x => !x.IsDelete).Where(x => x.ContractID == contractInput.Id);
                
                foreach(var detail in detailList)
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
                foreach(var product in contractInput.Products)
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

            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}