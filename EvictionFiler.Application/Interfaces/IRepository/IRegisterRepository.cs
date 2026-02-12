using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IRegisterRepository
    {
        Task AddFirmAsync(Firms firm);

        Task<Guid?> GetSubscriptionIdByNameAsync(string name);
        Task SaveChangesAsync();
       
    }
}
