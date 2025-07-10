using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			// Make sure Id is provided
			//if (dto.Id == Guid.Empty)
			//	dto.Id = Guid.NewGuid();
			var newlandlord = dtoList.Select(dto => new LandLord
            {
                Id = dto.Id,
                LandLordCode = dto.LandLordCode,
                Name = dto.Name,
                EINorSSN = dto.EINorSSN,
                Phone = dto.Phone,
                Email = dto.Email,
                MaillingAddress = dto.MaillingAddress,
                Attorney = dto.Attorney,
                Firm = dto.Firm,
                isCorporeateOwner = dto.isCorporeateOwner,
                RegisteredAgent = dto.RegisteredAgent,
                ClientId = dto.ClientId,
            });

            _mainDbContext.LandLords.AddRange(newlandlord);
            var result = await _mainDbContext.SaveChangesAsync();

            if(result != null)
            {
                return true;
            }
            return false;
        }

		public async Task<List<CreateLandLordDto>> GetAllLandLordsAsync()
		{
			var landlords = await _mainDbContext.LandLords
				.Where(x => x.IsDeleted != true)
				.ToListAsync();

			var result = landlords.Select(l => new CreateLandLordDto
			{
				Id = l.Id,
				LandLordCode = l.LandLordCode,
				Name = l.Name,
				EINorSSN = l.EINorSSN,
				Phone = l.Phone,
				Email = l.Email,
				MaillingAddress = l.MaillingAddress,
				Attorney = l.Attorney,
				Firm = l.Firm,
				isCorporeateOwner = l.isCorporeateOwner,
				RegisteredAgent = l.RegisteredAgent,
				
			}).ToList();

			return result;
		}


		public async Task<CreateLandLordDto?> GetLandLordByIdAsync(Guid id)
        {
			var l = await _mainDbContext.LandLords
		  .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != true);

			if (l == null)
				return null;

			return new CreateLandLordDto
			{
				LandLordCode = l.LandLordCode,
				Name = l.Name,
				EINorSSN = l.EINorSSN,
				Phone = l.Phone,
				Email = l.Email,
				MaillingAddress = l.MaillingAddress,
				Attorney = l.Attorney,
				Firm = l.Firm,
				isCorporeateOwner = l.isCorporeateOwner,
				RegisteredAgent = l.RegisteredAgent,
			};

		}
        public async Task<List<CreateLandLordDto>> SearchLandlordByCode(string code)
        {
            var landlord = await _mainDbContext.LandLords.Where(e => e.LandLordCode.Contains(code)).Select(e => new CreateLandLordDto
            {
                Id = e.Id,
                LandLordCode = e.LandLordCode,
                Name = e.Name,
                EINorSSN = e.EINorSSN,
                Phone = e.Phone,
                Email = e.Email,
                MaillingAddress = e.MaillingAddress,
                Attorney = e.Attorney,
                Firm = e.Firm,
                isCorporeateOwner = e.isCorporeateOwner,
                RegisteredAgent = e.RegisteredAgent,
                //ClientId = e.ClientId,
            }).ToListAsync();
            if (landlord == null)
                return new List<CreateLandLordDto>();
            return landlord;
        }

        public async Task<bool> UpdateLandLordAsync(CreateLandLordDto dto)
        {
            var existing = await _mainDbContext.LandLords.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.EINorSSN = dto.EINorSSN;
            existing.Phone = dto.Phone;
            existing.Email = dto.Email;
            existing.MaillingAddress = dto.MaillingAddress;
            existing.Attorney = dto.Attorney;
            existing.Firm = dto.Firm;
            existing.isCorporeateOwner = dto.isCorporeateOwner;
            existing.RegisteredAgent = dto.RegisteredAgent;

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
						l.Name.ToLower().StartsWith(query) ||
						l.LandLordCode.ToLower().StartsWith(query)
					)
				)
				.Select(l => new CreateLandLordDto
				{
					Id = l.Id,
					Name = l.Name,
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
					Country = appartment.Country,
					MDR_Number = appartment.MDR_Number,
					PetitionerInterest = appartment.PetitionerInterest,
					//IsActive = true,
					//CreatedAt = DateTime.UtcNow,
					LandlordId = appartment.LandlordId,
					Tanent = appartment.Tanent,
				}).ToListAsync();

			return new LandlordWithBuildings
			{
				Landlord = new CreateLandLordDto
				{
					Id = l.Id,
					LandLordCode = l.LandLordCode,
					Name = l.Name,
					EINorSSN = l.EINorSSN,
					Phone = l.Phone,
					Email = l.Email,
					MaillingAddress = l.MaillingAddress,
					Attorney = l.Attorney,
					Firm = l.Firm,
					isCorporeateOwner = l.isCorporeateOwner,
					RegisteredAgent = l.RegisteredAgent,
					// baki fields
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
				Name = l.Name,
				EINorSSN = l.EINorSSN,
				Phone = l.Phone,
				Email = l.Email,
				MaillingAddress = l.MaillingAddress,
				Attorney = l.Attorney,
				Firm = l.Firm,
				isCorporeateOwner = l.isCorporeateOwner,
				RegisteredAgent = l.RegisteredAgent,
			}).ToList();
		}



	}
}
