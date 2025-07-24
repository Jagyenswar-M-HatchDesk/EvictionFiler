using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.Services
{
	public class ApartmentService : IApartmentService
	{
		private readonly IApartmentRepository _repository;
		private readonly IUnitOfWork _unitOfWork;

		public ApartmentService(IApartmentRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}


		public async Task<List<AddApartment>> GetAll()
		{
			var newapartment = await _repository.GetAllAsync();
			return newapartment;
		}


		public async Task<bool> AddLandLordAsync(List<AddApartment> dtoList)
		{
			var newapartment = new List<Appartment>();

			var lastCode = await _repository.GetLastBuildingCodeAsync();

			int nextNumber = 1;
			if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
			{
				var numericPart = lastCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
				{
					nextNumber = lastNumber + 1;
				}
			}

			foreach (var appartment in dtoList)
			{
				var code = $"BB{nextNumber.ToString().PadLeft(10, '0')}";
				nextNumber++; // ✅ increment locally

				var apartment = new Appartment
				{
					Id = appartment.Id,
					BuildingCode = code,
					ApartmentCode = appartment.ApartmentCode,
					City = appartment.City,
					StateId = appartment.StateId,
					PremiseTypeId = appartment.PremiseTypeId,
					Address_1 = appartment.Address_1,
					Address_2 = appartment.Address_2,
					Zipcode = appartment.Zipcode,
					MDR_Number = appartment.MDR_Number,
					PetitionerInterest = appartment.PetitionerInterest,
					RentRegulationId = appartment.RentRegulationId,
					BuildingUnits = appartment.BuildingUnits,
					DateOfRefreeDeed = appartment.DateOfRefreeDeed,
					LandlordType = appartment.LandlordType,
					LandlordId = appartment.LandlordId,
					IsActive = appartment.IsActive,
					IsDeleted = appartment.IsDeleted,
					CreatedBy = appartment.CreatedBy,
					CreatedAt = appartment.CreatedAt,
					UpdatedAt = appartment.UpdatedAt,
					UpdatedBy = appartment.UpdatedBy,
				};

				newapartment.Add(apartment);
			}

			await _repository.AddRangeAsync(newapartment);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}
		
		public async Task<AddApartment> GetByIdAsync(Guid id)
		{
			var newapartment = await _repository.GetByIdAsync(id);
			return newapartment;
		}

		public async Task<List<AddApartment>> SearchBuildingByCode(string code, Guid landlordId)
		{
			return await _repository.SearchBuildingByCode(code, landlordId);
		}


		public async Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id)
		{
			return await _repository.GetBuildingsWithTenantAsync(id);
		}
		public async Task<List<EditApartmentDto>> GetBuildingsByLandlordIdAsync(Guid clientId)
		{
			var landlords = await _repository.GetBuildingsByLandlordIdAsync(clientId);
			return landlords;


		}

		public async Task<bool> UpdateBuildingAsync(List<EditApartmentDto> buildings)

		{
			var building = await _repository.UpdateBuildingAsync(buildings);
			return building;


		}

		public async Task<List<RegulationStatus>> GetAllRentRegulation()
		{
			var regulations = await _repository.GetAllRentRegulation();
			return regulations;
		}

		public async Task<List<PremiseType>> GetAllPremiseTypes()
		{

			var PremiseTypes = await _repository.GetAllPremiseType();
			return PremiseTypes;
		}
	}
}
