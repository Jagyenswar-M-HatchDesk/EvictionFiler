using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface IApartmentService
	{
		Task<List<AddApartment>> GetAll();
		Task<bool> AddApartmentAsync(List<AddApartment> dto);
		Task<AddApartment> GetByIdAsync(Guid id);
		Task<List<AddApartment>> SearchBuildingByCode(string code, Guid landlordId);
		Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id);
		Task<List<EditApartmentDto>> GetBuildingsByLandlordIdAsync(Guid clientId);
		Task<bool> UpdateBuildingAsync(List<EditApartmentDto> buildings);
		Task<List<RegulationStatus>> GetAllRentRegulation();
		Task<List<PremiseType>> GetAllPremiseTypes();
	}
}
