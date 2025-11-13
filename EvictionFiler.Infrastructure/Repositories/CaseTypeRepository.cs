using EvictionFiler.Application.DTOs.MasterDtos.ApperenceTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeHPDDto;
using EvictionFiler.Application.DTOs.MasterDtos.DefenseTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.HarassmentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefPetitionerTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefRespondentTypeDto;
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

        public async Task<List<CaseTypeHPDDto>> GetAllCaseTypeHPD()
        {
            var entities = await _context.MstCaseTypesHPD.ToListAsync();

            var dtos = entities.Select(e => new CaseTypeHPDDto
            {
                Id = e.Id,
                Name = e.Name,
              
            }).ToList();

            return dtos;
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

        public async Task<List<HarassmentTypeDto>> GetAllHarassmentTypes()
        {
            var entities = await _context.MstHarassmentTypes.ToListAsync();

            var dtos = entities.Select(e => new HarassmentTypeDto
            {
                Id = e.Id,
                Name = e.Name,

            }).ToList();

            return dtos;
        }

        public async Task<List<DefenseTypeDto>> GetAllDefenseTypes()
        {
            var entities = await _context.MstDefenseTypes.ToListAsync();

            var dtos = entities.Select(e => new DefenseTypeDto
            {
                Id = e.Id,
                Name = e.Name,

            }).ToList();

            return dtos;
        }

        public async Task<List<ApperenceTypeDto>> GetAllAppearanceTypes()
        {
            var entities = await _context.MstAppearanceTypes.ToListAsync();

            var dtos = entities.Select(e => new ApperenceTypeDto
            {
                Id = e.Id,
                Name = e.Name,

            }).ToList();

            return dtos;
        }

        public async Task<List<ReliefPetitionerTypeDto>> GetAllReliefPetitionerTypes()
        {
            var entities = await _context.MstReliefPetitionerTypes.ToListAsync();

            var dtos = entities.Select(e => new ReliefPetitionerTypeDto
            {
                Id = e.Id,
                Name = e.Name,

            }).ToList();

            return dtos;
        }

        public async Task<List<ReliefRespondentTypeDto>> GetAllReliefRespondentTypes()
        {
            var entities = await _context.MstReliefRespondentTypes.ToListAsync();

            var dtos = entities.Select(e => new ReliefRespondentTypeDto
            {
                Id = e.Id,
                Name = e.Name,

            }).ToList();

            return dtos;
        }

        public async Task<List<BilingType>> GetAllBilingTypes()
        {
            return await _context.MstBilingTypes.ToListAsync();
        }
    }
}
