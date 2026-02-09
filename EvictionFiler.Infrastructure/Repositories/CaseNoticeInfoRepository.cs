using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseNoticeInfoRepository : Repository<CaseNoticeInfo>, ICaseNoticeInfoRepository
    {
        private readonly MainDbContext _maindbcontext; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        public CaseNoticeInfoRepository(MainDbContext mainDbContext, IDbContextFactory<MainDbContext> contextFactory) : base(mainDbContext , contextFactory)
        {
            _maindbcontext = mainDbContext;
            _contextFactory = contextFactory;
        }

        public async Task<CaseNoticeInfo?> GetByCaseAndFormTypeAsync(Guid legalCaseId, Guid formTypeId)
        {
            return await _maindbcontext.CaseNoticeInfo
                .Where(x =>
                    x.LegalCaseId == legalCaseId &&
                    x.FormtypeId == formTypeId).FirstOrDefaultAsync();
        }
    }
}
