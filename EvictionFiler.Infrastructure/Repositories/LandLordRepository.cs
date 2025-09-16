using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository;
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
        public async Task<string> GenerateLandlordCodeAsync()
        {
            var lastCase = await _mainDbContext.LandLords
                .OrderByDescending(c => c.LandLordCode)
                .Select(c => c.LandLordCode)
                .FirstOrDefaultAsync();

            int nextNumber = 1;

            if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("LL"))
            {
                string numberPart = lastCase.Substring(2);
                if (int.TryParse(numberPart, out int parsedNumber))
                {
                    nextNumber = parsedNumber + 1;
                }
            }

            string newCode = "LL" + nextNumber.ToString("D10");
            return newCode;
        }

        public async Task<string?> GetLastLandLordCodeAsync()
		{
			return await _mainDbContext.LandLords
				.OrderByDescending(l => l.LandLordCode)
				.Select(l => l.LandLordCode)
				.FirstOrDefaultAsync();
		}
		public async Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query, Guid clientId)
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
				.Select(l => new EditToLandlordDto
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
				.Include(x => x.State)
				.Include(x => x.TypeOfOwner)
				.FirstOrDefaultAsync(x => x.Id == landlordId && x.IsDeleted != true);

			if (l == null) return null;

			var buildings = await _mainDbContext.Buildings
				.Include(a => a.State)
				.Include(a => a.PremiseType)
				.Include(a => a.RegulationStatus)
				.Where(a => a.LandlordId == landlordId && a.IsActive == true)
				.Select(b => new EditToBuildingDto
				{
					Id = b.Id,
					BuildingCode = b.BuildingCode,
					ApartmentCode = b.ApartmentCode,
					City = b.City,
					StateId = b.StateId,
					StateName = b.State.Name,
					PremiseTypeId = b.PremiseTypeId,
					PremiseTypeName = b.PremiseType.Name,
					Address1 = b.Address1,
					Address2 = b.Address2,
					Zipcode = b.Zipcode,
					MDRNumber = b.MDRNumber,
					PetitionerInterest = b.PetitionerInterest,
					RegulationStatusId = b.RegulationStatusId,
					RegulationStatusName = b.RegulationStatus.Name,
					BuildingUnits = b.BuildingUnits,
				
					LandlordId = b.LandlordId,

				}).ToListAsync();

			return new LandlordWithBuildings
			{
				Landlord = new EditToLandlordDto
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
					StateName = l.State?.Name,
					City = l.City,
					Zipcode = l.Zipcode,
					ContactPersonName = l.ContactPersonName,
					TypeOwnerId = l.TypeOfOwnerId,
					TypeOwnerName = l.TypeOfOwner?.Name,
					
				},
				Buildings = buildings
			};
		}

		public async Task<List<EditToLandlordDto>> GetByClientIdAsync(Guid? clientId)
		{
			var landlords = await _mainDbContext.LandLords
				.Where(x => x.ClientId == clientId && x.IsDeleted != true)
				.Include(x => x.State)
				.Include(x => x.LandlordType)
				.Include(x => x.TypeOfOwner)
				.ToListAsync();

			return landlords.Select(l => new EditToLandlordDto
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
				LandlordTypeId = l.LandlordTypeId,
				LandlordTypeName = l.LandlordType != null ? l.LandlordType.Name : string.Empty,
				StateName = l.State != null ? l.State.Name : string.Empty,
				TypeOwnerName = l.TypeOfOwner != null ? l.TypeOfOwner.Name : string.Empty,
				City = l.City,
				Zipcode = l.Zipcode,
				ContactPersonName = l.ContactPersonName,
				TypeOwnerId = l.TypeOfOwnerId,
				ClientId = l.ClientId,
				IsDeleted = l.IsDeleted,
				IsActive = l.IsActive,
				

			}).ToList();
		}

		public async Task<List<TypeOfOwner>> GetAllOwner()
		{
			return await _mainDbContext.MstTypeOfOwners.ToListAsync();
		}

		
	}
}
