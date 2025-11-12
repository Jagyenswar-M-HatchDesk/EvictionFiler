using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class CaseTypeRepository : Repository<CaseType>, ICaseTypeRepository
	{
		private readonly MainDbContext _context;

		public CaseTypeRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

        public async Task<List<CaseStatus>> GetAllCaseStatus()
        {
            return await _context.MstCaseStatus.ToListAsync();
        }

        public async Task<List<CaseType>> GetAllCaseType()
		{
			return await _context.MstCaseTypes.ToListAsync();
		}

        public async Task<List<County>> GetAllCounty()
        {
            return await _context.MstCounties.ToListAsync();
        }

        public async Task<List<CourtPart>> GetAllCourtPart()
        {
            return await _context.MstCourtPart.ToListAsync();
        }

        public async Task<List<CaseTypeHPD>> GetAllCaseTypeHPD()
        {
            return await _context.MstCaseTypesHPD.ToListAsync();
        }

        public async Task<List<PartyRepresent>> GetAllpartyRepresenting()
        {
            return await _context.MstPartyRepresents.ToListAsync();
        }

        public async Task<List<BuildingType>> GetAllBuildingTypes()
        {
            return await _context.MstBuildingTypes.ToListAsync();
        }

        public async Task<List<Registrationstatus>> GetAllRegistrationstatus()
        {
            return await _context.MstRegistrationstatuses.ToListAsync();
        }

        public async Task<List<HarassmentType>> GetAllHarassmentTypes()
        {
            return await _context.MstHarassmentTypes.ToListAsync();
        }

        public async Task<List<DefenseType>> GetAllDefenseTypes()
        {
            return await _context.MstDefenseTypes.ToListAsync();
        }

        public async Task<List<AppearanceType>> GetAllAppearanceTypes()
        {
            return await _context.MstAppearanceTypes.ToListAsync();
        }

        public async Task<List<ReliefPetitionerType>> GetAllReliefPetitionerTypes()
        {
            return await _context.MstReliefPetitionerTypes.ToListAsync();
        }

        public async Task<List<ReliefRespondentType>> GetAllReliefRespondentTypes()
        {
            return await _context.MstReliefRespondentTypes.ToListAsync();
        }

        public async Task<List<BilingType>> GetAllBilingTypes()
        {
            return await _context.MstBilingTypes.ToListAsync();
        }
    }
}
