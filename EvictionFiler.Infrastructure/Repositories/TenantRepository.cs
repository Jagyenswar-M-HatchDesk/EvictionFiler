using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<bool> AddTenant(List<CreateTenantDto> dtolist)
        {
            var newtenant = dtolist.Select(dto => new Tenant
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
                CreatedAt = DateTime.Now,
                IsActive = true,
                ApartmentId = dto.ApartmentId

            });
             _dbContext.Tenants.AddRange(newtenant);
            var result = await _dbContext.SaveChangesAsync();

            if(result != null)
            {
                return true;
            }

            return false;
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
                .Where(t => t.IsDeleted != true) // Optional: if soft delete is implemented
                .ToListAsync();
        }

        public async Task<bool> UpdateTenantAsync(CreateTenantDto dto)
        {
            var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (tenant == null) return false;

            tenant.Name = dto.Name;
            tenant.DOB = dto.DOB;
            tenant.SSN = dto.SSN;
            tenant.Phone = dto.Phone;
            tenant.Email = dto.Email;
            tenant.Language = dto.Language;
            tenant.Address = dto.Address;
            tenant.Apt = dto.Apt;
            tenant.Borough = dto.Borough;
            tenant.Rent = dto.Rent;
            tenant.LeaseStatus = dto.LeaseStatus;

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
            var tenant = await _dbContext.Tenants.Where(e=>e.TenantCode.Contains(code)).Select( e=> new CreateTenantDto
            {
                Id = e.Id,
                Name = e.Name,
                TenantCode = e.TenantCode,
                DOB = e.DOB,
                SSN = e.SSN,
                Phone = e.Phone,
                Email = e.Email,
                Language = e.Language,
                Address = e.Address,
                Apt = e.Apt,
                Borough = e.Borough,
                Rent = e.Rent,
                LeaseStatus = e.LeaseStatus
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
						l.Name.ToLower().StartsWith(query) ||
						l.TenantCode.ToLower().StartsWith(query)
					)
				)
				.Select(t => new CreateTenantDto
				{
					Id = t.Id,
					Name = t.Name,
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
			ApartmentId = dto.ApartmentId ?? Guid.Empty // fallback if null
		}).ToListAsync();


			return tenants;
		}


	}
}
