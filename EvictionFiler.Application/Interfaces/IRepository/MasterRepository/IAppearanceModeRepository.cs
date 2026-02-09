using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IAppearanceModeRepository : IRepository<AppearanceMode>
    {
        Task<IEnumerable<AppearanceMode>> GetAllAsync1(Expression<Func<AppearanceMode, bool>>? predicate = null, params Expression<Func<AppearanceMode, object>>[]? includes);
    }
}
