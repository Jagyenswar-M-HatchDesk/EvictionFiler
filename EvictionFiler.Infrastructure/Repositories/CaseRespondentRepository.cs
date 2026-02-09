using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseRespondentRepository : Repository<CaseAdditionalRespondent> , ICaseRespondentRepository
    {
        private readonly MainDbContext _maindbcontext; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        public CaseRespondentRepository(MainDbContext maindbcontext, IDbContextFactory<MainDbContext> contextFactory) : base(maindbcontext, contextFactory)
        {
            _maindbcontext = maindbcontext;
            _contextFactory = contextFactory;

        }
    }
}
