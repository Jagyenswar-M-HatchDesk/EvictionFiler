using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role?> GetByIdAsync(Guid id);
        Task<bool> UpdateRoleAsync(Role updatedRole);
    }
}
