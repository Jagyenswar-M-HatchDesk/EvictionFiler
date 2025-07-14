using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{ 
    public class TenantRepository : ITenantRepository
    {
        private readonly MainDbContext _dbContext;
        public TenantRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }



		public async Task<bool> AddTenant(List<CreateTenantDto> dtoList)
		{
			var newtenants = new List<Tenant>();

			foreach (var dto in dtoList)
			{
				var tenant = new Tenant
				{
					Id = dto.Id,
					TenantCode = await GenerateTenantCodeAsync(),
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
				};

				newtenants.Add(tenant);
			}

			_dbContext.Tenants.AddRange(newtenants);
			var result = await _dbContext.SaveChangesAsync();

			return result > 0;
		}
		public async Task<Tenant> GetTenantById(Guid id)
        {
            var tenant = await _dbContext.Tenants.FindAsync(id);
            if(tenant == null) 
                return new Tenant();
            return tenant;
        }
        public async Task<List<Tenant>> GetAllTenantsAsync()
        {
            return await _dbContext.Tenants
                .Where(t => t.IsDeleted != true)
                .ToListAsync();
        }
		public async Task<bool> UpdateTenantAsync(CreateTenantDto dto)
		{
			var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(x => x.Id == dto.Id);
			if (tenant == null) return false;


			tenant.TenantCode = dto.TenantCode;
			tenant.FirstName = dto.FirstName;
			tenant.LastName = dto.LastName;
			tenant.DOB = dto.DOB;
			tenant.SSN = dto.SSN;
			tenant.Phone = dto.Phone;
			tenant.Email = dto.Email;
			tenant.Language = dto.Language;
			tenant.Address_1 = dto.Address_1;
			tenant.Address_2 = dto.Address_2;
			tenant.State = dto.State;
			tenant.City = dto.City;
			tenant.Zipcode = dto.Zipcode;
			tenant.Apt = dto.Apt;
			tenant.Borough = dto.Borough;
			tenant.Rent = dto.Rent;
			tenant.LeaseStatus = dto.LeaseStatus;
			tenant.HasPossession = dto.HasPossession;
			tenant.HasRegulatedTenancy = dto.HasRegulatedTenancy;
			tenant.Name_Relation = dto.Name_Relation;
			tenant.OtherOccupants = dto.OtherOccupants;
			tenant.Registration_No = dto.Registration_No;
			tenant.TenantRecord = dto.TenantRecord;
			tenant.HasPriorCase = dto.HasPriorCase;
              
         


			_dbContext.Tenants.Update(tenant);
			await _dbContext.SaveChangesAsync();

			return true;
		}
		public async Task<bool> DeleteTenantAsync(Guid id)
        {
            var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(x => x.Id == id);
            if (tenant == null) return false;

            tenant.IsDeleted = true; // Assumes IsDeleted column exists
            _dbContext.Tenants.Update(tenant);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<CreateTenantDto>> SearchTenantByCode(string code)
        {
            var tenant = await _dbContext.Tenants.Where(e=>e.TenantCode.Contains(code)).Select( dto=> new CreateTenantDto
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

			}). ToListAsync();
            if (tenant == null)
                return new List<CreateTenantDto>();
            return tenant;
        }

		public async Task<List<CreateTenantDto>> SearchTenantAsync(string query , Guid BuildingId)
		{
			query = query?.Trim().ToLower() ?? "";

			var tenants = await _dbContext.Tenants
				.Where(l =>
					l.ApartmentId == BuildingId &&
					l.IsDeleted != true &&
					(
						l.FirstName.ToLower().StartsWith(query) ||
						l.TenantCode.ToLower().StartsWith(query)
					)
				)
				.Select(t => new CreateTenantDto
				{
					Id = t.Id,
					FirstName = t.FirstName,
					LastName = t.LastName,
					Email = t.Email,
					Phone = t.Phone,
					TenantCode = t.TenantCode // make sure this property exists in CreateTenantDto
				})
				.ToListAsync();

			return tenants;
		}



		public async Task<CreateTenantDto?> GetByIdAsync(Guid id)
		{
			var dto = await _dbContext.Tenants.FindAsync(id);

			if (dto == null)
				return null;

			return new CreateTenantDto
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
			};
		}

		public async Task<List<EditTenantDto>> GetTenantsByClientIdAsync(Guid clientId)
		{
			// Step 1: Get all landlord IDs for the client
			var landlordIds = await _dbContext.LandLords
				.Where(x => x.ClientId == clientId && x.IsDeleted != true)
				.Select(x => x.Id)
				.ToListAsync();

			// Step 2: Get all apartment IDs linked to these landlords
			var apartmentIds = await _dbContext.Appartments
		.Where(a => a.LandlordId.HasValue && landlordIds.Contains(a.LandlordId.Value) && a.IsDeleted != true)
		.Select(a => a.Id)
		.ToListAsync();


			// Step 3: Get all tenants linked to these apartments
			var tenants = await _dbContext.Tenants
		.Where(t => t.ApartmentId.HasValue && apartmentIds.Contains(t.ApartmentId.Value) && t.IsDeleted != true)
		.Select(dto => new EditTenantDto
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


			return tenants;
		}

		public async Task<string> GenerateTenantCodeAsync()
		{
			// Get the latest case from DB
			var lastCase = await _dbContext.Tenants
				.OrderByDescending(c => c.TenantCode)
				.Select(c => c.TenantCode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("TT"))
			{
				string numberPart = lastCase.Substring(2); // Remove 'EF'
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			// Generate new CaseCode
			string newCode = "TT" + nextNumber.ToString("D10"); // D10 = 10 digits
			return newCode;
		}

	}
}
