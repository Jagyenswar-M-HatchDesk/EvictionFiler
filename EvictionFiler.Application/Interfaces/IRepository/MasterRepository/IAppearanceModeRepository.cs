using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IAppearanceModeRepository : IRepository<AppearanceMode>
    {
        Task<IEnumerable<AppearanceMode>> GetAllAsync1(Expression<Func<AppearanceMode, bool>>? predicate = null, params Expression<Func<AppearanceMode, object>>[]? includes);
    }
}
