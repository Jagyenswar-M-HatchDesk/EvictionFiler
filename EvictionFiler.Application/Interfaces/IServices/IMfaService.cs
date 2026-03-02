using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IMfaService
    {
        Task<bool> SetGlobalMfaAsync(bool enable, Guid currentUserId, bool isSuperAdmin);
        Task<bool> GetGlobalMfaStatusAsync(Guid currentUserId, bool isSuperAdmin);
    }
}
