using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IVirtualPlatformRepository : IRepository<VirtualPlatform>
    {
        Task<IEnumerable<VirtualPlatform>> GetAllAsync1(Expression<Func<VirtualPlatform, bool>>? predicate = null, params Expression<Func<VirtualPlatform, object>>[]? includes);
    }
}
