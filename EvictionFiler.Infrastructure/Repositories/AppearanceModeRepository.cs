using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class AppearanceModeRepository :  Repository<AppearanceMode>, IAppearanceModeRepository
    {
            private readonly MainDbContext _mainDbContext;
            public AppearanceModeRepository(MainDbContext mainDbContext) : base(mainDbContext)
            {
                _mainDbContext = mainDbContext;
            }
        
    }
}
