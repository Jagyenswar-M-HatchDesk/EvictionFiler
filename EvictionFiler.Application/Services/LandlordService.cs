using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.Services
{
	public class LandlordService : ILandlordSevice
	{
		private readonly ILandLordRepository _landLordRepository;
		private readonly IUnitOfWork _unitOfWork;

		public LandlordService(ILandLordRepository landLordRepository , IUnitOfWork unitOfWork)
		{
			_landLordRepository = landLordRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> AddLandLordAsync(List<CreateLandLordDto> dtoList)
		{
			var newLandlords = new List<LandLord>();

			var lastCode = await _landLordRepository.GetLastLandLordCodeAsync();

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
				var code = $"LL{nextNumber.ToString().PadLeft(10, '0')}";
				nextNumber++;

				var landlord = new LandLord
				{
					Id = Guid.NewGuid(),
					LandLordCode = code,
					FirstName = dto.FirstName,
					LastName = dto.LastName,
					EINorSSN = dto.EINorSSN,
					Phone = dto.Phone,
					Email = dto.Email,
					Address1 = dto.Address1,
					Address2 = dto.Address2,
					StateId = dto.StateId,
					City = dto.City,
					Zipcode = dto.Zipcode,
					ContactPersonName = dto.ContactPersonName,
					TypeOfOwnerId = dto.TypeOfOwnerId,
					ClientId = dto.ClientId,
					CreatedAt = DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					CreatedBy = null,
					UpdatedBy = null,
					UpdatedAt = DateTime.Now,
				};

				newLandlords.Add(landlord);
			}

			await _landLordRepository.AddRangeAsync(newLandlords);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}


		public async Task<List<CreateLandLordDto>> SearchLandlordByCode(string code)
		{
			var newtenant = await _landLordRepository.SearchLandlordByCode(code);
			return newtenant;
		}

		public async Task<List<CreateLandLordDto>> GetAllLandLordsAsync()
		{
			var landlords = await _landLordRepository
				.GetAllQuerable(x => x.IsDeleted != true, x => x.States, x => x.TypeOfOwners)
				.ToListAsync();

			var result = landlords.Select(dto => new CreateLandLordDto
			{
				Id = dto.Id,
				LandLordCode = dto.LandLordCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				EINorSSN = dto.EINorSSN,
				Phone = dto.Phone,
				Email = dto.Email,
				Address1 = dto.Address1,
				Address2 = dto.Address2,
				StateId = dto.StateId,
				StateName = dto.States?.Name ?? "Unknown",
				TypeOfOwnerId = dto.TypeOfOwnerId,
				TypeOfOwnerName = dto.TypeOfOwners?.Name ?? "Unknown",
				City = dto.City,
				Zipcode = dto.Zipcode,
				ContactPersonName = dto.ContactPersonName,
				IsActive = dto.IsActive ?? false,
				IsDeleted = dto.IsDeleted ?? false,
				CreatedAt = dto.CreatedAt ?? DateTime.UtcNow,
				CreatedBy = dto.CreatedBy ?? "Admin",
				UpdatedAt = dto.UpdatedAt ?? DateTime.UtcNow,
				UpdatedBy = dto.UpdatedBy ?? "Admin"
			}).ToList();

			return result;
		}



		public async Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query, Guid clientId)
		{
			return await _landLordRepository.SearchLandlordsAsync(query, clientId);
		}

		public async Task<CreateLandLordDto?> GetLandLordByIdAsync(Guid id)
		{
			var dto = await _landLordRepository.GetAsync(id);


			if (dto == null)
				return null;

			return new CreateLandLordDto
			{
				Id = dto.Id,
				LandLordCode = dto.LandLordCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				EINorSSN = dto.EINorSSN,
				Phone = dto.Phone,
				Email = dto.Email,

				Address1 = dto.Address1,
				Address2 = dto.Address2,
				StateId = dto.StateId,
				City = dto.City,
				Zipcode = dto.Zipcode,
				ContactPersonName = dto.ContactPersonName,
				TypeOfOwnerId = dto.TypeOfOwnerId,
				IsDeleted = dto.IsDeleted,
				IsActive = dto.IsActive,
				CreatedAt = dto.CreatedAt,
				CreatedBy = dto.CreatedBy,
				UpdatedAt = dto.UpdatedAt,
				UpdatedBy = dto.UpdatedBy,
			}
			}

		public async Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId)
		{
			return await _landLordRepository.GetLandlordWithBuildingsAsync(landlordId);
		}

		public async Task<List<EditLandlordDto>> GetLandlordsByClientIdAsync(Guid clientId)
		{
			var landlords = await _landLordRepository.GetByClientIdAsync(clientId);
			return landlords;


		}

		public async Task<bool> UpdateLandLordsAsync(List<EditLandlordDto> landlords)

		{
			foreach (var l in landlords)
			{
				var entity = await _landLordRepository.GetAsync(l.Id);
				if (entity != null)
				{
					// Manually map updated values
					entity.FirstName = l.FirstName;
					entity.LastName = l.LastName;
					entity.Phone = l.Phone;
					entity.Email = l.Email;
					entity.Address1 = l.Address1;
					entity.Address2 = l.Address2;
					entity.TypeOfOwnerId = l.TypeOfOwnerId;
					entity.StateId = l.StateId;
					entity.City = l.City;
					entity.Zipcode = l.Zipcode;
					entity.EINorSSN = l.EINorSSN;
					entity.ContactPersonName = l.ContactPersonName;

					entity.IsActive = l.IsActive;
					entity.IsDeleted = l.IsDeleted;
					entity.CreatedBy = l.CreatedBy;
					entity.CreatedAt = l.CreatedAt;
					entity.UpdatedAt = l.UpdatedAt;
					entity.UpdatedBy = l.UpdatedBy;

				}
			}

			await _unitOfWork.SaveChangesAsync();
			return true;


		}


		public async Task<List<TypeOfOwner>> GetAllOwner()
		{

			var states = await _landLordRepository.GetAllOwner();
			return states;
		}
	}
}
