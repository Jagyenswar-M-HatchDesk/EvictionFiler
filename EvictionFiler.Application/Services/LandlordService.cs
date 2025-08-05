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

		public async Task<bool> AddLandLordAsync(List<CreateToLandLordDto> dtoList)
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
					DateOfRefreeDeed = dto.DateOfRefreeDeed,
					LandlordTypeId = dto.LandlordTypeId,
					TypeOfOwnerId = dto.TypeOwnerId,
					ClientId = dto.ClientId,
					CreatedOn = DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					UpdatedBy = null,
					UpdatedOn= DateTime.Now,
				};

				newLandlords.Add(landlord);
			}

			await _landLordRepository.AddRangeAsync(newLandlords);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}


		public async Task<List<CreateToLandLordDto>> GetAllLandLordsAsync()
		{
			var landlords = await _landLordRepository
				.GetAllQuerable(x => x.IsDeleted != true, x => x.State, x => x.TypeOfOwner)
				.ToListAsync();

			var result = landlords.Select(dto => new CreateToLandLordDto
			{
			
				LandLordCode = dto.LandLordCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				EINorSSN = dto.EINorSSN,
				Phone = dto.Phone,
				Email = dto.Email,
				Address1 = dto.Address1,
				Address2 = dto.Address2,
				StateId = dto.StateId,
				StateName = dto.State?.Name ?? "Unknown",
				TypeOwnerId = dto.TypeOfOwnerId,
				TypeOwnerName = dto.TypeOfOwner?.Name ?? "Unknown",
				LandlordTypeId = dto.LandlordTypeId,
				DateOfRefreeDeed = dto.DateOfRefreeDeed,
				LandlordTypeName = dto.LandlordType?.Name ?? "Unknown",
				City = dto.City,
				Zipcode = dto.Zipcode,
				ContactPersonName = dto.ContactPersonName,
			
			}).ToList();

			return result;
		}



		public async Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query, Guid clientId)
		{
			return await _landLordRepository.SearchLandlordsAsync(query, clientId);
		}

		public async Task<CreateToLandLordDto?> GetLandLordByIdAsync(Guid id)
		{
			var dto = await _landLordRepository.GetAsync(id);


			if (dto == null)
				return null;

			return new CreateToLandLordDto
			{
			
				LandLordCode = dto.LandLordCode,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				EINorSSN = dto.EINorSSN,
				Phone = dto.Phone,
				Email = dto.Email,
				Address1 = dto.Address1,
				Address2 = dto.Address2,
				StateId = dto.StateId,
				LandlordTypeId = dto.LandlordTypeId,
				LandlordTypeName= dto.LandlordType?.Name,
				DateOfRefreeDeed = dto.DateOfRefreeDeed,
				City = dto.City,
				Zipcode = dto.Zipcode,
				ContactPersonName = dto.ContactPersonName,
				TypeOwnerId = dto.TypeOfOwnerId,
			    TypeOwnerName = dto.TypeOfOwner?.Name,
			};
			}

		public async Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId)
		{
			return await _landLordRepository.GetLandlordWithBuildingsAsync(landlordId);
		}

		public async Task<List<EditToLandlordDto>> GetLandlordsByClientIdAsync(Guid? clientId)
		{
			var landlords = await _landLordRepository.GetByClientIdAsync(clientId);
			return landlords;


		}

		public async Task<bool> UpdateLandLordsAsync(List<EditToLandlordDto> landlords)

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
					entity.TypeOfOwnerId = l.TypeOwnerId;
					entity.StateId = l.StateId;
					entity.City = l.City;
					entity.Zipcode = l.Zipcode;
					entity.EINorSSN = l.EINorSSN;
					entity.LandlordTypeId = l.LandlordTypeId;
					entity.DateOfRefreeDeed = l.DateOfRefreeDeed;
					entity.ContactPersonName = l.ContactPersonName;
				}
			}

			await _unitOfWork.SaveChangesAsync();
			return true;


		}

	
	}
}
