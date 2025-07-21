using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Enums;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class LandLordRepository : ILandLordRepository
    {
        private readonly MainDbContext _mainDbContext;
        public LandLordRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }



		//public async Task<bool> AddLandLord(List<CreateLandLordDto> dtoList)
		//{
		//	var newLandlords = new List<LandLord>();

		//	foreach (var dto in dtoList)
		//	{
		//		var landlord = new LandLord
		//		{
		//			Id = dto.Id,

		//			LandLordCode = await GenerateLandlordCodeAsync(),
		//			FirstName = dto.FirstName,
		//			LastName = dto.LastName,
		//			EINorSSN = dto.EINorSSN,
		//			Phone = dto.Phone,
		//			Email = dto.Email,
		//			OtherProperties = dto.OtherProperties,
		//			Address1 = dto.Address1,
		//			Address2 = dto.Address2,
		//			State = dto.State,
		//			City = dto.City,
		//			Zipcode = dto.Zipcode,
		//			ContactPersonName = dto.ContactPersonName,
		//			TypeOfOwner = dto.TypeOfOwner,
		//			ClientId = dto.ClientId,
		//			CreatedAt = DateTime.Now,
		//			IsActive = true,
		//			IsDeleted = false,
		//			CreatedBy = null,
		//			UpdatedBy = null,
		//			UpdatedAt = DateTime.Now,
		//		};

		//		newLandlords.Add(landlord);
		//	}

		//	_mainDbContext.LandLords.AddRange(newLandlords);
		//	var result = await _mainDbContext.SaveChangesAsync();

		//	return result > 0;
		//}


		public async Task<bool> AddLandLord(List<CreateLandLordDto> dtoList)
		{
			var newLandlords = new List<LandLord>();

			// ✅ Fetch last landlord code only once
			var lastCode = await _mainDbContext.LandLords
				.OrderByDescending(l => l.CreatedAt)
				.Select(l => l.LandLordCode)
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

			foreach (var dto in dtoList)
			{
				var code = $"LL{nextNumber.ToString().PadLeft(10, '0')}";
				nextNumber++; // ✅ increment locally

				var landlord = new LandLord
				{
					Id = dto.Id,
					LandLordCode = code,
					FirstName = dto.FirstName,
					LastName = dto.LastName,
					EINorSSN = dto.EINorSSN,
					Phone = dto.Phone,
					Email = dto.Email,
					OtherProperties = dto.OtherProperties,
					Address1 = dto.Address1,
					Address2 = dto.Address2,
					State = dto.State,
					City = dto.City,
					Zipcode = dto.Zipcode,
					ContactPersonName = dto.ContactPersonName,
					TypeOfOwner = dto.TypeOfOwner,
					ClientId = dto.ClientId,
					CreatedAt = DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					CreatedBy = null,
					UpdatedBy = null,
					UpdatedAt = DateTime.Now,
				};

				newLandlords.Add(landlord);
			}

			_mainDbContext.LandLords.AddRange(newLandlords);
			var result = await _mainDbContext.SaveChangesAsync();

			return result > 0;
		}


		public async Task<List<CreateLandLordDto>> GetAllLandLordsAsync()
		{
			var landlords = await _mainDbContext.LandLords
				.Where(x => x.IsDeleted != true)
				.ToListAsync();

			var result = landlords.Select(dto => new CreateLandLordDto
			{
				
				Id = dto.Id,
				LandLordCode = dto.LandLordCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				EINorSSN = dto.EINorSSN,
				Phone = dto.Phone,
				Email = dto.Email,
				OtherProperties = dto.OtherProperties,
				Address1 = dto.Address1,
				Address2 = dto.Address2,
				State = dto.State,
				City = dto.City,
				Zipcode = dto.Zipcode,
				ContactPersonName = dto.ContactPersonName,
				TypeOfOwner = dto.TypeOfOwner,
				IsActive = dto.IsActive ?? false,
				IsDeleted = dto.IsDeleted ?? false,
				CreatedAt = dto.CreatedAt ?? DateTime.UtcNow,
				CreatedBy = dto.CreatedBy ?? "Admin",
				UpdatedAt = dto.UpdatedAt ?? DateTime.UtcNow,
				UpdatedBy = dto.UpdatedBy ?? "Admin"




			}).ToList();

			return result;
		}


		public async Task<CreateLandLordDto?> GetLandLordByIdAsync(Guid id)
        {
			var dto = await _mainDbContext.LandLords
		  .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

			if (dto == null)
				return null;

			return new CreateLandLordDto
			{
				Id = dto.Id,
				LandLordCode = dto.LandLordCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				EINorSSN = dto.EINorSSN,
				Phone = dto.Phone,
				Email = dto.Email,
				OtherProperties = dto.OtherProperties,
				Address1 = dto.Address1,
				Address2 = dto.Address2,
				State = dto.State,
				City = dto.City,
				Zipcode = dto.Zipcode,
				ContactPersonName = dto.ContactPersonName,
				TypeOfOwner = dto.TypeOfOwner,
				IsDeleted = dto.IsDeleted,
				IsActive  = dto.IsActive,
				CreatedAt = dto.CreatedAt,
				CreatedBy = dto.CreatedBy,
				UpdatedAt = dto.UpdatedAt,
				UpdatedBy = dto.UpdatedBy,
				
			};

		}
        public async Task<List<CreateLandLordDto>> SearchLandlordByCode(string code)
        {
            var landlord = await _mainDbContext.LandLords.Where(e => e.LandLordCode.Contains(code)).Select(e => new CreateLandLordDto
            {
				Id = e.Id,
				LandLordCode = e.LandLordCode,
				//Name = e.Name,
				EINorSSN = e.EINorSSN,
				Phone = e.Phone,
				Email = e.Email,
		
				
				ContactPersonName = e.ContactPersonName,
				
				TypeOfOwner = e.TypeOfOwner,
			}).ToListAsync();
            if (landlord == null)
                return new List<CreateLandLordDto>();
            return landlord;
        }

		public async Task<bool> UpdateLandLordsAsync(List<EditLandlordDto> landlords)
		{
			foreach (var l in landlords)
			{
				var entity = await _mainDbContext.LandLords.FindAsync(l.Id);
				if (entity != null)
				{
					// Manually map updated values
					entity.FirstName = l.FirstName;
					entity.LastName = l.LastName;
					entity.Phone = l.Phone;
					entity.Email = l.Email;
					entity.Address1 = l.Address1;
					entity.Address2 = l.Address2;
					entity.TypeOfOwner = l.TypeOfOwner;
					entity.State = l.State;
					entity.City = l.City;
					entity.Zipcode = l.Zipcode;
					entity.EINorSSN = l.EINorSSN;
					entity.ContactPersonName = l.ContactPersonName;
					entity.OtherProperties = l.OtherProperties;
					entity.IsActive = l.IsActive;
					entity.IsDeleted = l.IsDeleted;
					entity.CreatedBy  = l.CreatedBy;
					entity.CreatedAt = l.CreatedAt;
					entity.UpdatedAt = l.UpdatedAt;
					entity.UpdatedBy = l.UpdatedBy;
				
				}
			}

			await _mainDbContext.SaveChangesAsync();
			return true;
		}


		public async Task<bool> DeleteLandLordAsync(Guid id)
        {
            var landLord = await _mainDbContext.LandLords.FirstOrDefaultAsync(x => x.Id == id);
            if (landLord == null) return false;

            landLord.IsDeleted = true; // Mark as deleted
            _mainDbContext.LandLords.Update(landLord);
            await _mainDbContext.SaveChangesAsync();

            return true;
        }


		public async Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query, Guid clientId)
		{
			query = query?.Trim().ToLower() ?? "";

			var landlords = await _mainDbContext.LandLords
				.Where(l =>
					l.ClientId == clientId &&                
					l.IsDeleted != true &&
					(
						l.FirstName.ToLower().StartsWith(query) ||
						l.LandLordCode.ToLower().StartsWith(query)
					)
				)
				.Select(l => new CreateLandLordDto
				{
					Id = l.Id,
					FirstName = l.FirstName,
					Email = l.Email,
					Phone = l.Phone,
					LandLordCode = l.LandLordCode
				})
				.ToListAsync();

			return landlords;
		}
		public async Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId)
		{
			var l = await _mainDbContext.LandLords
				.FirstOrDefaultAsync(x => x.Id == landlordId && x.IsDeleted != true);

			if (l == null) return null;

			var buildings = await _mainDbContext.Appartments
				.Where(a => a.LandlordId == landlordId && a.IsDeleted != true)
				.Select(appartment  => new AddApartment
				{
					Id = appartment.Id,
					BuildingCode = appartment.BuildingCode,
					ApartmentCode = appartment.ApartmentCode,
					City = appartment.City,
					State = appartment.State,
					PremiseType = appartment.PremiseType,
					Address_1 = appartment.Address_1,
					Address_2 = appartment.Address_2,
					Zipcode = appartment.Zipcode,
					MDR_Number = appartment.MDR_Number,
					PetitionerInterest = appartment.PetitionerInterest,
					TypeOfRentRegulation = appartment.TypeOfRentRegulation,
					BuildingUnits = appartment.BuildingUnits,
					DateOfRefreeDeed = appartment.DateOfRefreeDeed,
					LandlordType = appartment.LandlordType,
					LandlordId = appartment.LandlordId,
					IsDeleted = appartment.IsDeleted,
					IsActive = appartment.IsActive,
					CreatedAt	= appartment.CreatedAt,
					CreatedBy = appartment.CreatedBy,
					UpdatedBy = appartment.UpdatedBy,
					UpdatedAt	= appartment.UpdatedAt,

				}).ToListAsync();

			return new LandlordWithBuildings
			{
				Landlord = new CreateLandLordDto
				{
					Id = l.Id,
					LandLordCode = l.LandLordCode,
					FirstName = l.FirstName,
					LastName = l.LastName,
					EINorSSN = l.EINorSSN,
					Phone = l.Phone,
					Email = l.Email,
					OtherProperties = l.OtherProperties,
					Address1 = l.Address1,
					Address2 = l.Address2,
					State = l.State,
					City = l.City,
					Zipcode = l.Zipcode,
					ContactPersonName = l.ContactPersonName,
					TypeOfOwner = l.TypeOfOwner,
					IsActive= l.IsActive,
					IsDeleted = l.IsDeleted,
					CreatedBy	=	l.CreatedBy,
					CreatedAt = l.CreatedAt,
					UpdatedAt = l.UpdatedAt,
					UpdatedBy= l.UpdatedBy,


				},
				Buildings = buildings
			};
		}
		public async Task<List<EditLandlordDto>> GetByClientIdAsync(Guid clientId)
		{
			var landlords = await _mainDbContext.LandLords
				.Where(x => x.ClientId == clientId && x.IsDeleted != true)
				.ToListAsync();

			return landlords.Select(l => new EditLandlordDto
			{
				Id = l.Id,
				LandLordCode = l.LandLordCode,
				FirstName = l.FirstName,
				LastName = l.LastName,
				EINorSSN = l.EINorSSN,
				Phone = l.Phone,
				Email = l.Email,
				OtherProperties = l.OtherProperties,
				Address1 = l.Address1,
				Address2 = l.Address2,
				State = l.State,
				City = l.City,
				Zipcode = l.Zipcode,
				ContactPersonName = l.ContactPersonName,
				TypeOfOwner = l.TypeOfOwner,
				ClientId = l.ClientId,
				IsActive = l.IsActive,
				IsDeleted = l.IsDeleted,
				CreatedBy = l.CreatedBy,
				CreatedAt = l.CreatedAt,
				UpdatedAt = l.UpdatedAt,
				UpdatedBy = l.UpdatedBy,

			}).ToList();
		}

		private static Dictionary<Guid, int> _clientLandlordCounters = new();


		//public async Task<string> GenerateLandlordCodeAsync()
		//{
		//	var lastCode = await _mainDbContext.LandLords
		//		.OrderByDescending(l => l.CreatedAt)
		//		.Select(l => l.LandLordCode)
		//		.FirstOrDefaultAsync();

		//	int nextNumber = 1;

		//	if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
		//	{
		//		var numericPart = lastCode.Substring(2); // Remove "LL"
		//		if (int.TryParse(numericPart, out int lastNumber))
		//		{
		//			nextNumber = lastNumber + 1;
		//		}
		//	}

		//	return $"LL{nextNumber.ToString().PadLeft(10, '0')}";
		//}



	}
}
