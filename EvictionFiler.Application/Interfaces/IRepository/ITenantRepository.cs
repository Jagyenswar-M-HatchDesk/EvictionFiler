using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ITenantRepository : IRepository<Tenant>
	{

        Task<string?> GetLasttenantCodeAsync();

		Task<List<CreateTenantDto>> SearchTenantByCode(string code); 

		Task<List<CreateTenantDto>> SearchTenantAsync(string query, Guid BuildingId);

		Task<List<EditTenantDto>> GetTenantsByClientIdAsync(Guid clientId);
        Task<List<Language>> GetAllLanguage();
		

	}
}
