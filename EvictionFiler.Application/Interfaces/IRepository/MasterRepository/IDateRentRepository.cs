using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IDateRentRepository : IRepository<DateRent>
    {
        Task<List<DateRent>> GetAllDateRent();
    }
}
