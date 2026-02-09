using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface IReasonHoldoverRepository : IRepository<ReasonHoldover>
    {
		Task<List<ReasonHoldover>> GetAllTReasonHoldover();
	}
}
