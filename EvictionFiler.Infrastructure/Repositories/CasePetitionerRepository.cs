using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
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
    public class CasePetitionerRepository :Repository<CaseAdditionalPetitioner>, ICasePetitionerRepository
    {
        private readonly MainDbContext _maindbcontext; private readonly IDbContextFactory<MainDbContext> _contextFactory; 
        public CasePetitionerRepository(MainDbContext mainDbContext, IDbContextFactory<MainDbContext> contextFactory) : base (mainDbContext, contextFactory)
        {
            _maindbcontext = mainDbContext;
            _contextFactory = contextFactory;

        }
    }
}
