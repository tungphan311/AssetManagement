using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Providers;
using GWebsite.AbpZeroTemplate.Application.Share.Providers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Providers
{
    public class ProviderAppService : GWebsiteAppServiceBase, IProviderAppService
    {
        private readonly IRepository<Provider> providerRepository;

        public ProviderAppService(IRepository<Provider> providerRepository)
        {
            this.providerRepository = providerRepository;
        }

        #region Public Method

        public void CreateOrEditProvider(ProviderInput ProviderInput)
        {
            try
            {
                if (ProviderInput.Id == 0)
                {
                    Create(ProviderInput);
                }
                else
                {
                    Update(ProviderInput);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Provider COE: " + e.ToString());
            }
        }

        public void DeleteProvider(int id)
        {
            var ProviderEntity = providerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProviderEntity != null)
            {
                ProviderEntity.IsDelete = true;
                providerRepository.Update(ProviderEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ProviderInput GetProviderForEdit(int id)
        {
            var ProviderEntity = providerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProviderEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProviderInput>(ProviderEntity);
        }

        public ProviderForViewDto GetProviderForView(int id)
        {
            var providerEntity = providerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (providerEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProviderForViewDto>(providerEntity);
        }

        public PagedResultDto<ProviderDto> GetProviders(ProviderFilter input)
        {
            var query = providerRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(input.Name));
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
            return new PagedResultDto<ProviderDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProviderDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Provider_Create)]
        private void Create(ProviderInput providerInput)
        {
            try
            {

                var providerEntity = ObjectMapper.Map<Provider>(providerInput);
                if (providerEntity == null) System.Console.WriteLine("null: ");
                SetAuditInsert(providerEntity);
                providerRepository.Insert(providerEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Provider Create: " + e.ToString());
            }

        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Provider_Edit)]
        private void Update(ProviderInput providerInput)
        {
            var providerEntity = providerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == providerInput.Id);
            if (providerEntity == null)
            {
            }
            ObjectMapper.Map(providerInput, providerEntity);
            SetAuditEdit(providerEntity);
            providerRepository.Update(providerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
