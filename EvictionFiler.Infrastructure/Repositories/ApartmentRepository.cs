using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly MainDbContext _context;

        public ApartmentRepository(MainDbContext context)
        {
            _context = context;
        }

		public async Task<string?> GetLastBuildingCodeAsync()
		{
			return await _context.Appartments
				.OrderByDescending(l => l.CreatedAt)
				.Select(l => l.BuildingCode)
				.FirstOrDefaultAsync();
		}

		public async Task AddRangeAsync(List<Appartment> buildings)
		{
			await _context.Appartments.AddRangeAsync(buildings);
		}
		public async Task<AddApartment?> GetByIdAsync(Guid id)
        {
            var appartment  =  await _context.Appartments.FindAsync(id);

			if (appartment == null)
				return null;

			return new AddApartment
			{
				Id = appartment.Id,
				BuildingCode = appartment.BuildingCode,
				ApartmentCode = appartment.ApartmentCode,
				City = appartment.City,
				StateId = appartment.StateId,
				RentRegulationId = appartment.RentRegulationId,
				PremiseTypeId = appartment.PremiseTypeId,
				Address_1 = appartment.Address_1,
				Address_2 = appartment.Address_2,
				Zipcode = appartment.Zipcode,	
				MDR_Number = appartment.MDR_Number,
				PetitionerInterest = appartment.PetitionerInterest,
				BuildingUnits = appartment.BuildingUnits,
				DateOfRefreeDeed =appartment.DateOfRefreeDeed,
				LandlordType = appartment.LandlordType,
				LandlordId = appartment.LandlordId,
				IsActive = appartment.IsActive,
				IsDeleted = appartment.IsDeleted,
				CreatedBy = appartment.CreatedBy,
				CreatedAt = appartment.CreatedAt,
				UpdatedAt = appartment.UpdatedAt,
				UpdatedBy = appartment.UpdatedBy,

			};
		}


        public async Task<List<AddApartment>> GetAllAsync()
        {

			return await _context.Appartments
	   .Where(a => a.IsDeleted == false || a.IsDeleted == null)
	   .Select(appartment => new AddApartment
	   {
		   Id = appartment.Id,
		   BuildingCode = appartment.BuildingCode,
		   ApartmentCode = appartment.ApartmentCode,
		   City = appartment.City,
		   StateId = appartment.StateId,
		   RentRegulationId = appartment.RentRegulationId,
		   PremiseTypeId = appartment.PremiseTypeId,
		   Address_1 = appartment.Address_1,
		   Address_2 = appartment.Address_2,
		   Zipcode = appartment.Zipcode,
		   MDR_Number = appartment.MDR_Number,
		   PetitionerInterest = appartment.PetitionerInterest,
		  
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
	   }).ToListAsync();
			
        }


		public async Task<bool> AddApartmentAsync(List<AddApartment> dtoList)
		{
			var newapartment = new List<Appartment>();

			// ✅ Fetch last landlord code only once
			var lastCode = await _context.Appartments
				.OrderByDescending(l => l.CreatedAt)
				.Select(l => l.BuildingCode)
				.FirstOrDefaultAsync();

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
					BuildingCode =code,
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

			_context.Appartments.AddRange(newapartment);
			var result = await _context.SaveChangesAsync();

			return result > 0;
		}

		public async Task<BuildingWithTenant?> GetBuildingsWithTenantAsync(Guid id)
		{
			var appartment = await _context.Appartments
				.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

			if (appartment == null) return null;

			var tenant = await _context.Tenants
				.Where(a => a.ApartmentId == id && a.IsDeleted != true)
				.Select(dto => new CreateTenantDto
				{
					Id = dto.Id,
					TenantCode = dto.TenantCode,
					FirstName = dto.FirstName,
					LastName = dto.LastName,
					DOB = dto.DOB,
					SSN = dto.SSN,
					Phone = dto.Phone,
					Email = dto.Email,
					LanguageId = dto.LanguageId,
					
					StateId = dto.StateId,
					Address_1 = dto.Address_1,
					Address_2 = dto.Address_2,
					City = dto.City,
					Zipcode = dto.Zipcode,
					Apt = dto.Apt,
					Borough = dto.Borough,
					Rent = dto.Rent,
					HasPossession = dto.HasPossession,
					HasRegulatedTenancy = dto.HasRegulatedTenancy,
					Name_Relation = dto.Name_Relation,
					OtherOccupants = dto.OtherOccupants,
					Registration_No = dto.Registration_No,
					TenantRecord = dto.TenantRecord,
					HasPriorCase = dto.HasPriorCase,
					ApartmentId = dto.ApartmentId,
					IsActive = dto.IsActive,
					IsDeleted = dto.IsDeleted,
					CreatedBy = dto.CreatedBy,
					CreatedAt = dto.CreatedAt,
					UpdatedAt = dto.UpdatedAt,
					UpdatedBy = dto.UpdatedBy,
				}).ToListAsync();

            return new BuildingWithTenant
            {
              
                Building = new AddApartment
                {
					Id = appartment.Id,
					BuildingCode = appartment.BuildingCode,
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

				},
				Tenants = tenant
			};
		}
		public async Task<bool> UpdateBuildingAsync(List<EditApartmentDto> buildings)
		{
			foreach (var appartment in buildings)
			{
				var entity = await _context.Appartments.FindAsync(appartment.Id);
				if (entity != null)
				{
					// Manually map updated values
					entity.ApartmentCode = appartment.ApartmentCode;
					entity.BuildingCode = appartment.BuildingCode;
					entity.City = appartment.City;
					entity.StateId = appartment.StateId;

					entity.PremiseTypeId = appartment.PremiseTypeId;
					entity.Address_1 = appartment.Address_1;
					entity.Address_2 = appartment.Address_2;
					entity.Zipcode = appartment.Zipcode;
					entity.MDR_Number = appartment.MDR_Number;
					entity.PetitionerInterest = appartment.PetitionerInterest;
					entity.RentRegulationId = appartment.RentRegulationId;
					entity.BuildingUnits = appartment.BuildingUnits;
					entity.DateOfRefreeDeed = appartment.DateOfRefreeDeed;
					entity.LandlordType = appartment.LandlordType;
					entity.LandlordId = appartment.LandlordId;
					entity.IsActive = appartment.IsActive;
					entity.IsDeleted = appartment.IsDeleted;
					entity.CreatedBy = appartment.CreatedBy;
					entity.CreatedAt = appartment.CreatedAt;
					entity.UpdatedAt = appartment.UpdatedAt;
					entity.UpdatedBy = appartment.UpdatedBy;
				}
			}

			await _context.SaveChangesAsync();
			return true;
		}

		public async Task DeleteAsync(Guid id)
        {
            var appartment = await _context.Appartments.FindAsync(id);
            if (appartment != null)
            {
                _context.Appartments.Remove(appartment);
                await _context.SaveChangesAsync();
            }
        }

		public async Task<List<AddApartment>> SearchBuildingByCode(string code, Guid landlordId)
		{
			return await _context.Appartments
				.Where(appartment =>
					appartment.LandlordId == landlordId && // ✅ only selected landlord's buildings
					appartment.BuildingCode.StartsWith(code)
				)
				.Select(appartment=> new AddApartment
				{
					Id = appartment.Id,
					BuildingCode = appartment.BuildingCode,
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

				})
				.ToListAsync();
		}

		public async Task<List<EditApartmentDto>> GetBuildingsByLandlordIdAsync(Guid landlordId)
		{
			var building = await _context.Appartments
		.Include(a => a.States)
		.Include(a => a.premiseTypes)
		.Include(a => a.regulationStatus)
		.Where(x => x.LandlordId == landlordId && x.IsDeleted != true)
		.ToListAsync();

			return building.Select(appartment  => new EditApartmentDto
			{
				Id = appartment.Id,
				BuildingCode = appartment.BuildingCode,
				ApartmentCode = appartment.ApartmentCode,
				City = appartment.City,
				StateId = appartment.StateId,
				StateName = appartment.States?.Name,
				PremiseTypeId = appartment.PremiseTypeId,
				PremiseName = appartment.premiseTypes?.Name,
				RentRegulationId = appartment.RentRegulationId,
				RentRegulationName = appartment.regulationStatus?.Name,
				Address_1 = appartment.Address_1,
				Address_2 = appartment.Address_2,
				Zipcode = appartment.Zipcode,
				MDR_Number = appartment.MDR_Number,
				PetitionerInterest = appartment.PetitionerInterest,
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

			}).ToList();
		}


		public async Task<List<PremiseType>> GetAllPremiseType()
		{
			return await _context.mst_PremiseTypes.ToListAsync();
		}


		public async Task<List<RegulationStatus>> GetAllRentRegulation()
		{
			return await _context.mst_regulationStatus.ToListAsync();
		}


	}
}