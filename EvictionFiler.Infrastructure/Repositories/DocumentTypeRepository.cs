using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
    {
        private readonly MainDbContext _maindbcontext; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        public DocumentTypeRepository(MainDbContext mainDbContext, IDbContextFactory<MainDbContext> contextFactory) : base(mainDbContext, contextFactory)
        {
            _maindbcontext = mainDbContext;
            _contextFactory = contextFactory;

        }


    }
}
