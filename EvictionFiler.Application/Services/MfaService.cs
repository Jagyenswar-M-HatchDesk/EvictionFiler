using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;

namespace EvictionFiler.Application.Services
{
    public class MfaService : IMfaService
    {
        private readonly IMfaRepository _mfaRepository;

        public MfaService(IMfaRepository mfaRepository)
        {
            
            _mfaRepository = mfaRepository;
        }

        public async Task<bool> SetGlobalMfaAsync(bool enable, Guid currentUserId, bool isSuperAdmin)
        {
            return await _mfaRepository.SetGlobalMfaAsync(enable, currentUserId, isSuperAdmin);
        }

        public async Task<bool> GetGlobalMfaStatusAsync(Guid currentUserId, bool isSuperAdmin)
        {
            return await _mfaRepository.GetGlobalMfaStatusAsync(currentUserId, isSuperAdmin);
        }
    }
}
