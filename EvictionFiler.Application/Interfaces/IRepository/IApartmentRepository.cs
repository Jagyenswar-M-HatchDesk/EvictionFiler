using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IApartmentRepository : IRepository<Appartment>
    {
		Task<string?> GetLastBuildingCodeAsync();
		//Task AddRangeAsync(List<Appartment> buildings);

 
        Task<List<AddApartment>> SearchBuildingByCode(string code, Guid landlordId);
		Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id);
        Task<List<EditApartmentDto>> GetBuildingsByLandlordIdAsync(Guid landlordId);
        Task<List<RegulationStatus>> GetAllRentRegulation();
        Task<List<PremiseType>> GetAllPremiseType();

	}
}
