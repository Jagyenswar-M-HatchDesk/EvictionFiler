using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IApartmentRepository
    {
        Task<Appartment?> GetByIdAsync(Guid id);
        Task<List<Appartment>> GetAllAsync();
        Task AddAsync(Appartment appartment);
        Task UpdateAsync(Appartment appartment);
        Task DeleteAsync(Guid id);
    }
}
