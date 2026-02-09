using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IRenewalStatusRepository : IRepository<RenewalStatus>
    {
        Task<List<RenewalStatus>> GetAllRenewalStatus();
    }
}
