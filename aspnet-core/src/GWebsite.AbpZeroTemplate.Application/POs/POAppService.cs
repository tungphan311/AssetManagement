using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.POs;
using GWebsite.AbpZeroTemplate.Application.Share.POs.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.POs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class POAppService : GWebsiteAppServiceBase, IPOAppService
    {
        private readonly IRepository<PO> poRepository;
        private readonly IRepository<Vendor> vendorRepository;
        private readonly IRepository<Contract> contractRepository;

        public POAppService(IRepository<PO> repository, IRepository<Vendor> vendorRepository, IRepository<Contract> contractRepository)
        {
            poRepository = repository;
            this.vendorRepository = vendorRepository;
            this.contractRepository = contractRepository;
        }

        #region public method

        public void CreateOrEditPO(POInput input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Update(input);
            }
        }

        public void DeletePO(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDelete = true;
                poRepository.Update(entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public POInput GetPOForEdit(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<POInput>(entity);
        }

        public POForViewDto GetPOForView(int id)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<POForViewDto>(entity);
        }

        public PagedResultDto<PODto> GetPOs(POFilter input)
        {
            var query = poRepository.GetAll().Where(x => !x.IsDelete);
            var contract = contractRepository.GetAll().Where(x => !x.IsDelete);
            var vendor = vendorRepository.GetAll().Where(x => !x.IsDelete);

            if (input.POID != null)
            {
                query = query.Where(x => x.POID.ToLower().Contains(input.POID.ToLower()));
            }

            if (input.OrderName != null)
            {
                query = query.Where(x => x.OrderName.ToLower().Contains(input.OrderName.ToLower()));
            }

            if (input.ContractID != null)
            {
                var contracts = contract.Where(x => x.Name.ToLower().Contains(input.ContractID.ToLower())).ToList();

                query = query.Where(x => isExist(contracts, x.ContractID));
            }

            if (input.VendorID != null)
            {
                var vendors = vendor.Where(x => x.Name.ToLower().Contains(input.VendorID.ToLower())).ToList();

                query = query.Where(x => isVendorExist(vendors, x.VendorID));
            }

            if (input.Type == "in")
            {
                query = query.Where(x => x.ContractID != 0);
            }
            else if (input.Type == "out")
            {
                query = query.Where(x => x.ContractID == 0);
            }

            var totalCount = query.Count();

            // sort
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<PODto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PODto>(item)).ToList());
        }

        #endregion

        #region private method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(POInput input)
        {
            var entity = ObjectMapper.Map<PO>(input);
            SetAuditInsert(entity);
            poRepository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(POInput input)
        {
            var entity = poRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (entity == null)
            {

            }
            ObjectMapper.Map(input, entity);
            SetAuditEdit(entity);
            poRepository.Update(entity);
            CurrentUnitOfWork.SaveChanges();
        }

        private bool isExist(List<Contract> contracts, int id)
        {
            foreach(var contract in contracts)
            {
                if (contract.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isVendorExist(List<Vendor> vendors, int id)
        {
            foreach (var vendor in vendors)
            {
                if (vendor.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
