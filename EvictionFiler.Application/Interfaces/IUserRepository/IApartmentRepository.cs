using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IApartmentRepository
    {
        Task<AddApartment?> GetByIdAsync(Guid id);
        Task<List<Appartment>> GetAllAsync();
        Task<bool> AddApartmentAsync(List<AddApartment> dtolist);

		Task UpdateAsync(Appartment appartment);
        Task DeleteAsync(Guid id);
        Task<List<AddApartment>> SearchBuildingByCode(string code);
        Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id);


	}
}
