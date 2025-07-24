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
				.OrderByDescending(l => l.CreatedAt)
				.Select(l => l.TenantCode)
				.FirstOrDefaultAsync();
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
				LanguageId = dto.LanguageId,
				StateId = dto.StateId,
				Address_1 = dto.Address_1,
				Address_2 = dto.Address_2,
				City = dto.City,
				Zipcode = dto.Zipcode,
				Apt = dto.Apt,
				Borough = dto.Borough,
				Rent = dto.Rent,
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

	
		public async Task<List<EditTenantDto>> GetTenantsByClientIdAsync(Guid buildingId)
		{



			var apartmentIds = await _dbContext.Appartments
			.Where(a => a.Id == buildingId && (a.IsDeleted == false || a.IsDeleted == null))
			.Select(a => a.Id)
			.ToListAsync();


			// Step 3: Get all tenants linked to these apartments
			var tenants = await _dbContext.Tenants
		.Include(a => a.States)
		.Include(a => a.Languages)
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
			LanguageId = dto.LanguageId,
			StateId = dto.StateId,
			StateName = dto.States.Name,
			LanguageName = dto.Languages.Name,
			Address_1 = dto.Address_1,
			Address_2 = dto.Address_2,
			City = dto.City,
			Zipcode = dto.Zipcode,
			Apt = dto.Apt,
			Borough = dto.Borough,
			Rent = dto.Rent,
			
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


		public async Task<List<Language>> GetAllLanguage()
		{
			return await _dbContext.mst_Languages.ToListAsync();
		}

	}
}
