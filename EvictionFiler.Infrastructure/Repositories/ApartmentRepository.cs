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
				MDR_Number = appartment.MDR_Number,
				PetitionerInterest = appartment.PetitionerInterest,
				TypeOfRentRegulation = appartment.TypeOfRentRegulation,
				BuildingUnits = appartment.BuildingUnits,
				DateOfRefreeDeed =appartment.DateOfRefreeDeed,
				LandlordType = appartment.LandlordType,
				LandlordId = appartment.LandlordId,
		
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
					FirstName = dto.FirstName,
					LastName = dto.LastName,
					DOB = dto.DOB,
					SSN = dto.SSN,
					Phone = dto.Phone,
					Email = dto.Email,
					Language = dto.Language,
					Address_1 = dto.Address_1,
					Address_2 = dto.Address_2,
					State = dto.State,
					City = dto.City,
					Zipcode = dto.Zipcode,
					Apt = dto.Apt,
					Borough = dto.Borough,
					Rent = dto.Rent,
					LeaseStatus = dto.LeaseStatus,
					HasPossession = dto.HasPossession,
					HasRegulatedTenancy = dto.HasRegulatedTenancy,
					Name_Relation = dto.Name_Relation,
					OtherOccupants = dto.OtherOccupants,
					Registration_No = dto.Registration_No,
					TenantRecord = dto.TenantRecord,
					HasPriorCase = dto.HasPriorCase,


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
					MDR_Number = appartment.MDR_Number,
					PetitionerInterest = appartment.PetitionerInterest,
					TypeOfRentRegulation = appartment.TypeOfRentRegulation,
					BuildingUnits = appartment.BuildingUnits,
					DateOfRefreeDeed = appartment.DateOfRefreeDeed,
					LandlordType = appartment.LandlordType,
					LandlordId = appartment.LandlordId,

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
				.Where(appartment =>
					appartment.LandlordId == landlordId && // ✅ only selected landlord's buildings
					appartment.ApartmentCode.StartsWith(code)
				)
				.Select(appartment=> new AddApartment
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

				})
				.ToListAsync();
		}

		public async Task<List<EditApartmentDto>> GetBuildingsByLandlordIdAsync(Guid landlordId)
		{
			var building  = await _context.Appartments
				.Where(x => x.LandlordId == landlordId && x.IsDeleted != true)
				.ToListAsync();

			return building.Select(appartment  => new EditApartmentDto
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

			}).ToList();
		}



	}
}