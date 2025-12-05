using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IRemainderCenterRepository : IRepository<RemainderCenter>
    {
        Task<bool> DeleteAllAsync();
    }
}
