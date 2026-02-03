using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface IAppearanceTypeRepository : IRepository<AppearanceType>
    {
        Task<IEnumerable<AppearanceType>> GetAllAsync1(Expression<Func<AppearanceType, bool>>? predicate = null, params Expression<Func<AppearanceType, object>>[]? includes);

    }
}
