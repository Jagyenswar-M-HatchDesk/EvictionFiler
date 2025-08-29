using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ICaseSubTypeRepository
	{
		Task<List<CaseSubType>> GetSubTypesByCaseTypeIdAsync(Guid caseTypeId);
	}
}
