using EvictionFiler.Application.DTOs.MasterDtos.ApperenceTypeDto;
//using EvictionFiler.Application.DTOs.MasterDtos.CountyHPDDto;
//using EvictionFiler.Application.DTOs.MasterDtos.CountyPerDiemDto;
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
	public class CountyRepository : Repository<County>, ICountyRepository
	{
		private readonly MainDbContext _context;

		public CountyRepository(MainDbContext context) : base(context)
		{
			_context = context;
		}

    }
}
