using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IRemainderTypeRepository
    {
        Task<List<RemainderType>> GetAllRemainderTypes();
    }
}
