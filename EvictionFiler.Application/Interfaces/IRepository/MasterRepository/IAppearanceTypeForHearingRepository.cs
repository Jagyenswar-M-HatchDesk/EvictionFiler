using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface IAppearanceTypeForHearingRepository : IRepository<AppearanceTypeforHearing>
    {
        Task<IEnumerable<AppearanceTypeforHearing>> GetAllAsync1(Expression<Func<AppearanceTypeforHearing, bool>>? predicate = null, params Expression<Func<AppearanceTypeforHearing, object>>[]? includes);

    }
}
