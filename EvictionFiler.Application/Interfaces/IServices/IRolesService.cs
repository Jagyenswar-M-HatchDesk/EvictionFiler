using EvictionFiler.Application.DTOs.RolesDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IRolesService
    {
        Task<IEnumerable<RolesDto>> GetAllRolesAsync();
        Task<RolesDto?> GetRoleByIdAsync(Guid id);
        Task<bool> UpdateRoleAsync(RolesDto role);
        Task<bool> DeleteRoleAsync(Guid id);
    }
}
