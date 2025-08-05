using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ITenantRepository : IRepository<Tenant>
	{

        Task<string?> GetLasttenantCodeAsync();
		Task<List<CreateToTenantDto>> SearchTenantByCode(string code); 
		Task<List<EditToTenantDto>> SearchTenantAsync(string query, Guid BuildingId);
		Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId);
        Task<List<Language>> GetAllLanguage();
		

	}
}
