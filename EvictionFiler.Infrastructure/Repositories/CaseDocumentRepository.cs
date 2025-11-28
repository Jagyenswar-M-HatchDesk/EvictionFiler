using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseDocumentRepository : Repository<CaseDocument>, ICaseDocument
    {
        private readonly MainDbContext _context;

        public CaseDocumentRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
