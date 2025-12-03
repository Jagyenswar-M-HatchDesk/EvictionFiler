using EvictionFiler.Application.DTOs.MasterDtos.ApperenceTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeHPDDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypePerDiemDto;
using EvictionFiler.Application.DTOs.MasterDtos.DefenseTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.DocumentInstructionPerDiemDto;
using EvictionFiler.Application.DTOs.MasterDtos.HarassmentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefPetitionerTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReliefRespondentTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.ReportingRequirementPerDiemDto;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
	public class RemainderTypeRepository : Repository<RemainderType>, IRemainderTypeRepository
    {
		private readonly MainDbContext _context;

		public RemainderTypeRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

        public async Task<List<RemainderType>> GetAllRemainderTypes()
        {
            return await _context.MstRemainderTypes.ToListAsync();
        }

      
    }
}
