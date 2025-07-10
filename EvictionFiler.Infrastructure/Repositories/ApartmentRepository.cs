using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
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

        public async Task<AddApartment?> GetByIdAsync(Guid id)
        {
            var appartment  =  await _context.Appartments.FindAsync(id);

			if (appartment == null)
				return null;

			return new AddApartment
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
			};
		}


        public async Task<List<Appartment>> GetAllAsync()
        {
            return await _context.Appartments.Where(e=>e.IsDeleted != true).ToListAsync();
        }

		public async Task<bool> AddApartmentAsync(List<AddApartment> dtolist)
		{
            var newapartment = dtolist.Select(appartment=> new Appartment
            {
                Id = appartment.Id,
                ApartmentCode = appartment.ApartmentCode,
                City = appartment.City,
                State = appartment.State,
                PremiseType= appartment.PremiseType,
                Address_1 = appartment.Address_1,
                Address_2 = appartment.Address_2,
                Zipcode = appartment.Zipcode,
                Country = appartment.Country,
                MDR_Number = appartment.MDR_Number,
                PetitionerInterest = appartment.PetitionerInterest,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                LandlordId = appartment.LandlordId,
                Tanent = appartment.Tanent,

            });
            _context.Appartments.AddRange(newapartment);
            var result =await _context.SaveChangesAsync();
            if(result != null)
                return true;
            return false;
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
					Name = dto.Name,
					DOB = dto.DOB,
					SSN = dto.SSN,
					Phone = dto.Phone,
					Email = dto.Email,
					Language = dto.Language,
					Address = dto.Address,
					Apt = dto.Apt,
					Borough = dto.Borough,
					Rent = dto.Rent,
					LeaseStatus = dto.LeaseStatus,
				
					ApartmentId = dto.ApartmentId
				}).ToListAsync();

            return new BuildingWithTenant
            {
              
                Building = new AddApartment
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
                    LandlordId = appartment.LandlordId,
                    Tanent = appartment.Tanent,
                },
				Tenants = tenant
			};
		}


		public async Task UpdateAsync(Appartment appartment)
        {
            _context.Appartments.Update(appartment);
            await _context.SaveChangesAsync();
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
				.Where(e =>
					e.LandlordId == landlordId && // ✅ only selected landlord's buildings
					e.ApartmentCode.StartsWith(code)
				)
				.Select(e => new AddApartment
				{
					Id = e.Id,
					ApartmentCode = e.ApartmentCode,
					City = e.City,
					State = e.State,
					PremiseType = e.PremiseType,
					Address_1 = e.Address_1,
					Address_2 = e.Address_2,
					Zipcode = e.Zipcode,
					Country = e.Country,
					MDR_Number = e.MDR_Number,
					PetitionerInterest = e.PetitionerInterest,
					LandlordId = e.LandlordId,
					Tanent = e.Tanent
				})
				.ToListAsync();
		}

		public async Task<List<EditApartmentDto>> GetBuildingsByLandlordIdAsync(Guid landlordId)
		{
			var building  = await _context.Appartments
				.Where(x => x.LandlordId == landlordId && x.IsDeleted != true)
				.ToListAsync();

			return building.Select(e => new EditApartmentDto
			{
				Id = e.Id,
				ApartmentCode = e.ApartmentCode,
				City = e.City,
				State = e.State,
				PremiseType = e.PremiseType,
				Address_1 = e.Address_1,
				Address_2 = e.Address_2,
				Zipcode = e.Zipcode,
				Country = e.Country,
				MDR_Number = e.MDR_Number,
				PetitionerInterest = e.PetitionerInterest,
				LandlordId = e.LandlordId,
				Tanent = e.Tanent
			}).ToList();
		}



	}
}