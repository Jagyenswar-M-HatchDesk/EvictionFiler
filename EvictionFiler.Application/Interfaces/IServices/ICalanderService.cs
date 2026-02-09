using EvictionFiler.Application.DTOs.CalanderDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICalanderService
    {
        Task<bool> GenrateCalander(CalanderDto dto);
        Task<List<CalanderDto>> GetAllCalanderAsync();
    }
}
