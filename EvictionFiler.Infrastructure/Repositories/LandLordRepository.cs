using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class LandLordRepository : Repository<LandLord>,  ILandLordRepository
	{
        private readonly MainDbContext _mainDbContext;

        public LandLordRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

		public async Task<string?> GetLastLandLordCodeAsync()
		{
			return await _mainDbContext.LandLords
				.OrderByDescending(l => l.CreatedAt)
				.Select(l => l.LandLordCode)
				.FirstOrDefaultAsync();
		}

		public async Task AddRangeAsync(List<LandLord> landlords)
		{
			await _mainDbContext.LandLords.AddRangeAsync(landlords);
		}

        public async Task<List<CreateLandLordDto>> SearchLandlordByCode(string code)
        {
            var landlord = await _mainDbContext.LandLords.Where(e => e.LandLordCode.Contains(code)).Select(e => new CreateLandLordDto
            {
				Id = e.Id,
				LandLordCode = e.LandLordCode,
				//Name = e.Name,
				EINorSSN = e.EINorSSN,
				Phone = e.Phone,
				Email = e.Email,
		
				
				ContactPersonName = e.ContactPersonName,
				
				//TypeOfOwner = e.TypeOfOwner,
			}).ToListAsync();
            if (landlord == null)
                return new List<CreateLandLordDto>();
            return landlord;
        }
		public async Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query, Guid clientId)
		{
			query = query?.Trim().ToLower() ?? "";

			var landlords = await _mainDbContext.LandLords
				.Where(l =>
					l.ClientId == clientId &&                
					l.IsDeleted != true &&
					(
						l.FirstName.ToLower().StartsWith(query) ||
						l.LandLordCode.ToLower().StartsWith(query)
					)
				)
				.Select(l => new CreateLandLordDto
				{
					Id = l.Id,
					FirstName = l.FirstName,
					Email = l.Email,
					Phone = l.Phone,
					LandLordCode = l.LandLordCode
				})
				.ToListAsync();

			return landlords;
		}
		public async Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId)
		{
			// Landlord include State & TypeOfOwner
			var l = await _mainDbContext.LandLords
				.Include(x => x.States)
				.Include(x => x.TypeOfOwners)
				.FirstOrDefaultAsync(x => x.Id == landlordId && x.IsDeleted != true);

			if (l == null) return null;

			// Appartments include related tables
			var buildings = await _mainDbContext.Appartments
				.Include(a => a.States)
				.Include(a => a.premiseTypes)
				.Include(a => a.regulationStatus)
				.Where(a => a.LandlordId == landlordId && a.IsDeleted != true)
				.Select(appartment => new AddApartment
				{
					Id = appartment.Id,
					BuildingCode = appartment.BuildingCode,
					ApartmentCode = appartment.ApartmentCode,
					City = appartment.City,
					StateId = appartment.StateId,
					StateName = appartment.States.Name,
					PremiseTypeId = appartment.PremiseTypeId,
					PremiseName = appartment.premiseTypes.Name,
					Address_1 = appartment.Address_1,
					Address_2 = appartment.Address_2,
					Zipcode = appartment.Zipcode,
					MDR_Number = appartment.MDR_Number,
					PetitionerInterest = appartment.PetitionerInterest,
					RentRegulationId = appartment.RentRegulationId,
					RentRegulationName = appartment.regulationStatus.Name,
					BuildingUnits = appartment.BuildingUnits,
					DateOfRefreeDeed = appartment.DateOfRefreeDeed,
					LandlordType = appartment.LandlordType,
					LandlordId = appartment.LandlordId,
					IsDeleted = appartment.IsDeleted,
					IsActive = appartment.IsActive,
					CreatedAt = appartment.CreatedAt,
					CreatedBy = appartment.CreatedBy,
					UpdatedBy = appartment.UpdatedBy,
					UpdatedAt = appartment.UpdatedAt,
				}).ToListAsync();

			return new LandlordWithBuildings
			{
				Landlord = new CreateLandLordDto
				{
					Id = l.Id,
					LandLordCode = l.LandLordCode,
					FirstName = l.FirstName,
					LastName = l.LastName,
					EINorSSN = l.EINorSSN,
					Phone = l.Phone,
					Email = l.Email,
					Address1 = l.Address1,
					Address2 = l.Address2,
					StateId = l.StateId,
					StateName = l.States.Name,
					City = l.City,
					Zipcode = l.Zipcode,
					ContactPersonName = l.ContactPersonName,
					TypeOfOwnerId = l.TypeOfOwnerId,
					TypeOfOwnerName = l.TypeOfOwners.Name,
					IsActive = l.IsActive,
					IsDeleted = l.IsDeleted,
					CreatedBy = l.CreatedBy,
					CreatedAt = l.CreatedAt,
					UpdatedAt = l.UpdatedAt,
					UpdatedBy = l.UpdatedBy,
				},
				Buildings = buildings
			};
		}

		public async Task<List<EditLandlordDto>> GetByClientIdAsync(Guid clientId)
		{
			var landlords = await _mainDbContext.LandLords
				.Where(x => x.ClientId == clientId && x.IsDeleted != true)
				.Include(x => x.States)
				.Include(x => x.TypeOfOwners)
				.ToListAsync();

			return landlords.Select(l => new EditLandlordDto
			{
				Id = l.Id,
				LandLordCode = l.LandLordCode,
				FirstName = l.FirstName,
				LastName = l.LastName,
				EINorSSN = l.EINorSSN,
				Phone = l.Phone,
				Email = l.Email,
				Address1 = l.Address1,
				Address2 = l.Address2,
				StateId = l.StateId,
				StateName = l.States?.Name,              
				TypeOfOwnerName = l.TypeOfOwners?.Name,  
				City = l.City,
				Zipcode = l.Zipcode,
				ContactPersonName = l.ContactPersonName,
				TypeOfOwnerId = l.TypeOfOwnerId,
				ClientId = l.ClientId,
				IsActive = l.IsActive,
				IsDeleted = l.IsDeleted,
				CreatedBy = l.CreatedBy,
				CreatedAt = l.CreatedAt,
				UpdatedAt = l.UpdatedAt,
				UpdatedBy = l.UpdatedBy,

			}).ToList();
		}

		public async Task<List<TypeOfOwner>> GetAllOwner()
		{
			return await _mainDbContext.mst_TypeOfOwners.ToListAsync();
		}


	}
}
