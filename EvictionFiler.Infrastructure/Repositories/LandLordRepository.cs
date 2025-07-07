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


		public async Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query)
		{
			var landlords = await _mainDbContext.LandLords
				.Where(l => l.Name.Contains(query) && l.IsDeleted != true)
				.Select(l => new CreateLandLordDto
				{
					Id = l.Id,
					Name = l.Name,
					Email = l.Email,
					Phone = l.Phone,
					LandLordCode = l.LandLordCode
				}).ToListAsync();

			return landlords;
		}


	}
}
