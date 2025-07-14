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

		public async Task<bool> AddLandLord(List<CreateLandLordDto> dtoList)
		{
			var newLandlords = new List<LandLord>();

			foreach (var dto in dtoList)
			{
				var landlord = new LandLord
				{
					Id = dto.Id,
					LandLordCode = await GenerateLandlordCodeAsync(),
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
					ClientId = dto.ClientId
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

        public async Task<bool> UpdateLandLordAsync(CreateLandLordDto dto)
        {
            var existing = await _mainDbContext.LandLords.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (existing == null) return false;


			existing.LandLordCode = dto.LandLordCode;
			existing.FirstName = dto.FirstName;
			existing.LastName = dto.LastName;
			existing.EINorSSN = dto.EINorSSN;
			existing.Phone = dto.Phone;
			existing.Email = dto.Email;
			existing.OtherProperties = dto.OtherProperties;
			existing.Address1 = dto.Address1;
			existing.Address2 = dto.Address2;
			existing.State = dto.State;
			existing.City = dto.City;
			existing.Zipcode = dto.Zipcode;
			existing.ContactPersonName = dto.ContactPersonName;
			existing.TypeOfOwner = dto.TypeOfOwner;
					


			_mainDbContext.LandLords.Update(existing);
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
				ClientId = l.ClientId

			}).ToList();
		}

		public async Task<string> GenerateLandlordCodeAsync()
		{
			// Get the latest case from DB
			var lastCase = await _mainDbContext.LandLords
				.OrderByDescending(c => c.LandLordCode)
				.Select(c => c.LandLordCode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("LL"))
			{
				string numberPart = lastCase.Substring(2); // Remove 'EF'
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			// Generate new CaseCode
			string newCode = "LL" + nextNumber.ToString("D10"); // D10 = 10 digits
			return newCode;
		}

	}
}
