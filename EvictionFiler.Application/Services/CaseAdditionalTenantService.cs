using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Services
{
    public class CaseAdditionalTenantService : ICaseAdditionalTenantService
    {
        private readonly ICaseAdditionalTenantRepository _repository;
        public CaseAdditionalTenantService(ICaseAdditionalTenantRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAdditionalCaseTenantAsync(List<AddtionalTenantDto> tenat)
        {

            await _repository.AddAdditionalCaseTenant(tenat);
        }

        public async Task<List<CaseAdditionalTenants>> GetAllAdditionalCaseTenantsAsync(Guid? Id)
        {
            var additional = await _repository.GetAdditionalCaseTenants(Id);
            return additional;
        }

        public async Task<bool> UpdateAdditionalCaseTenantAsync(List<AddtionalTenantDto> tenants)
        {

            return await _repository.UpdateAdditionalCaseTenant(tenants);
        }

        public async Task<bool> DeleteAdditionalCaseTenants(List<AddtionalTenantDto> tenants)
        {
                return await _repository.DeleteAdditionalTenants(tenants);
        }
    }
}
