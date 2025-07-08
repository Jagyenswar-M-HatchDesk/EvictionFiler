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

		public async Task<List<CreateTenantDto>> SearchTenantAsync(string query)
		{
			var tenants = await _dbContext.Tenants
				.Where(l => l.Name.Contains(query) && l.IsDeleted != true)
				.Select(l => new CreateTenantDto
				{
					Id = l.Id,
					Name = l.Name,
					Email = l.Email,
					Phone = l.Phone,
					
				}).ToListAsync();

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

	}
}
