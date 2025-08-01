﻿using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{ 
    public class TenantRepository : Repository<Tenant>,  ITenantRepository
    {
        private readonly MainDbContext _dbContext;
        public TenantRepository(MainDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

		public async Task<string?> GetLasttenantCodeAsync()
		{
			return await _dbContext.Tenants
				.OrderByDescending(l => l.CreatedOn)
				.Select(l => l.TenantCode)
				.FirstOrDefaultAsync();
		}

        public async Task<List<CreateToTenantDto>> SearchTenantByCode(string code)
        {
            var tenant = await _dbContext.Tenants.Where(e=>e.TenantCode.Contains(code)).Select( dto=> new CreateToTenantDto
            {
				
				TenantCode = dto.TenantCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
			
				SSN = dto.SSN,
				Phone = dto.Phone,
				Email = dto.Email,
				LanguageId = dto.LanguageId,
			
				Borough = dto.Borough,
			
				HasPossession = dto.HasPossession,
				HasRegulatedTenancy = dto.HasRegulatedTenancy,
				Name_Relation = dto.Name_Relation,
				OtherOccupants = dto.OtherOccupants,
				Registration_No = dto.Registration_No,
				TenantRecord = dto.TenantRecord,
				HasPriorCase = dto.HasPriorCase,
				BuildingId = dto.BuildinId

			}). ToListAsync();
            if (tenant == null)
                return new List<CreateToTenantDto>();
            return tenant;
        }

		public async Task<List<EditToTenantDto>> SearchTenantAsync(string query , Guid BuildingId)
		{
			query = query?.Trim().ToLower() ?? "";

			var tenants = await _dbContext.Tenants
				.Where(l =>
					l.BuildinId == BuildingId &&
					l.IsDeleted != true &&
					(
						l.FirstName.ToLower().StartsWith(query) ||
						l.TenantCode.ToLower().StartsWith(query)
					)
				)
				.Select(t => new EditToTenantDto
				{
					Id = t.Id,
					FirstName = t.FirstName,
					LastName = t.LastName,
					Email = t.Email,
					Phone = t.Phone,
					TenantCode = t.TenantCode 
				})
				.ToListAsync();

			return tenants;
		}

	
		public async Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid buildingId)
		{
			var apartmentIds = await _dbContext.Buildings
			.Where(a => a.Id == buildingId && (a.IsDeleted == false || a.IsDeleted == null))
			.Select(a => a.Id)
			.ToListAsync();


			// Step 3: Get all tenants linked to these apartments
			var tenants = await _dbContext.Tenants
		.Include(a => a.Language)
		.Where(t => t.BuildinId.HasValue && apartmentIds.Contains(t.BuildinId.Value) && t.IsDeleted != true)
		.Select(dto => new EditToTenantDto
		{
			Id = dto.Id,
			TenantCode = dto.TenantCode,
			FirstName = dto.FirstName,
			LastName = dto.LastName,
		
			SSN = dto.SSN,
			Phone = dto.Phone,
			Email = dto.Email,
			LanguageId = dto.LanguageId,
			LanguageName = dto.Language.Name,
			Borough = dto.Borough,
	
			HasPossession = dto.HasPossession,
			HasRegulatedTenancy = dto.HasRegulatedTenancy,
			Name_Relation = dto.Name_Relation,
			OtherOccupants = dto.OtherOccupants,
			Registration_No = dto.Registration_No,
			TenantRecord = dto.TenantRecord,
			HasPriorCase = dto.HasPriorCase,
			BuildingId = dto.BuildinId
		}).ToListAsync();


			return tenants;
		}


		public async Task<List<Language>> GetAllLanguage()
		{
			return await _dbContext.MstLanguages.ToListAsync();
		}

	}
}
