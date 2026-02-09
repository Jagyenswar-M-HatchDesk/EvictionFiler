using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface IRegulationStatusRepository : IRepository<RegulationStatus>
    {
		Task<List<RegulationStatus>> GetAllRegulationStatus();
	}
}
