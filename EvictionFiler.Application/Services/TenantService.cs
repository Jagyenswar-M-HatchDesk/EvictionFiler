using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.Services
{
    public class TenantService : ITenantService
    {
		private readonly ITenantRepository _repo;
		private readonly IUnitOfWork _unitOfWork;

		public TenantService(ITenantRepository services , IUnitOfWork unitOfWork)
		{
			_repo = services;
			_unitOfWork = unitOfWork;
		}

		

	public async Task<bool> AddTenantAsync(List<CreateTenantDto> dtoList)
		{
			var newtenant = new List<Tenant>();

			var lastCode = await _repo.GetLasttenantCodeAsync();

			int nextNumber = 1;
			if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
			{
				var numericPart = lastCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
				{
					nextNumber = lastNumber + 1;
				}
			}

			foreach (var dto in dtoList)
			{
				var code = $"TT{nextNumber.ToString().PadLeft(10, '0')}";
				nextNumber++; // ✅ increment locally

				var tenant = new Tenant
				{
					Id = dto.Id,
					TenantCode = code,
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
					IsActive = dto.IsActive,
					IsDeleted = dto.IsDeleted,
					CreatedBy = dto.CreatedBy,
					CreatedAt = dto.CreatedAt,
					UpdatedAt = dto.UpdatedAt,
					UpdatedBy = dto.UpdatedBy,

					ApartmentId = dto.ApartmentId
				};

				newtenant.Add(tenant);
			}

			await _repo.AddRangeAsync(newtenant);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}

		public async Task<List<CreateTenantDto>> SearchTenantbyCode(string code)
		{
			var newtenant = await _repo.SearchTenantByCode(code);
			return newtenant;
		}

		public async Task<List<CreateTenantDto>> SearchTenantsAsync(string query, Guid buildingId)
		{
			return await _repo.SearchTenantAsync(query, buildingId);
		}

		public async Task<EditTenantDto> GetByIdAsync(Guid id)
		{
			var tenant = await _repo.GetAsync(id);

			if (tenant == null)
				return null;

			return new EditTenantDto
			{
				Id = tenant.Id,
				TenantCode = tenant.TenantCode,
				FirstName = tenant.FirstName,
				LastName = tenant.LastName,
				DOB = tenant.DOB,
				SSN = tenant.SSN,
				Phone = tenant.Phone,
				Email = tenant.Email,
				LanguageId = tenant.LanguageId,
				StateId = tenant.StateId,
				Address_1 = tenant.Address_1,
				Address_2 = tenant.Address_2,
				City = tenant.City,
				Zipcode = tenant.Zipcode,
				Apt = tenant.Apt,
				Borough = tenant.Borough,
				Rent = tenant.Rent,
				HasPossession = tenant.HasPossession,
				HasRegulatedTenancy = tenant.HasRegulatedTenancy,
				Name_Relation = tenant.Name_Relation,
				OtherOccupants = tenant.OtherOccupants,
				Registration_No = tenant.Registration_No,
				TenantRecord = tenant.TenantRecord,
				HasPriorCase = tenant.HasPriorCase,
				IsActive = tenant.IsActive,
				IsDeleted = tenant.IsDeleted,
				CreatedBy = tenant.CreatedBy,
				CreatedAt = tenant.CreatedAt,
				UpdatedAt = tenant.UpdatedAt,
				UpdatedBy = tenant.UpdatedBy,

				ApartmentId = tenant.ApartmentId
			};
	}

		public async Task<List<EditTenantDto>> GetTenantsByClientIdAsync(Guid clientId)
		{
			var tenants = await _repo.GetTenantsByClientIdAsync(clientId);
			return tenants;


		}
		public async Task<bool> UpdateTenantAsync(List<EditTenantDto> dtoList)

		{
			foreach (var dto in dtoList)
			{
				var entity = await _repo.GetAsync(dto.Id);
				if (entity != null)
				{
					entity.TenantCode = dto.TenantCode;
					entity.FirstName = dto.FirstName;
					entity.LastName = dto.LastName;
					entity.DOB = dto.DOB;
					entity.SSN = dto.SSN;
					entity.Phone = dto.Phone;
					entity.Email = dto.Email;
					entity.LanguageId = dto.LanguageId;
					entity.StateId = dto.StateId;
					entity.Address_1 = dto.Address_1;
					entity.Address_2 = dto.Address_2;
					entity.City = dto.City;
					entity.Zipcode = dto.Zipcode;
					entity.Apt = dto.Apt;
					entity.Borough = dto.Borough;
					entity.Rent = dto.Rent;
					entity.HasPossession = dto.HasPossession;
					entity.HasRegulatedTenancy = dto.HasRegulatedTenancy;
					entity.Name_Relation = dto.Name_Relation;
					entity.OtherOccupants = dto.OtherOccupants;
					entity.Registration_No = dto.Registration_No;
					entity.TenantRecord = dto.TenantRecord;
					entity.HasPriorCase = dto.HasPriorCase;
					entity.ApartmentId = dto.ApartmentId;
					entity.IsActive = dto.IsActive;
					entity.IsDeleted = dto.IsDeleted;
					entity.CreatedBy = dto.CreatedBy;
					entity.CreatedAt = dto.CreatedAt;
					entity.UpdatedAt = dto.UpdatedAt;
					entity.UpdatedBy = dto.UpdatedBy;
					entity.HasPriorCase = dto.HasPriorCase;
				}

				_repo.UpdateAsync(entity);
				await _unitOfWork.SaveChangesAsync();
			}
			return true;
	}
		public async Task<List<Language>> GetAllLanguage()
		{
			await Task.Delay(4000);
			var lang = await _repo.GetAllLanguage();
			return lang;
		}

		public async Task<List<CreateTenantDto>> GetAll()
		{
			var query = await _repo.GetAllAsync();
			return query.Select(dto => new CreateTenantDto
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
				IsActive = dto.IsActive,
				IsDeleted = dto.IsDeleted,
				CreatedBy = dto.CreatedBy,
				CreatedAt = dto.CreatedAt,
				UpdatedAt = dto.UpdatedAt,
				UpdatedBy = dto.UpdatedBy,

				ApartmentId = dto.ApartmentId
			}).ToList();
		}
	}
}
