using EvictionFiler.Application.DTOs.RemainderCenterDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IRemianderCenterService
    {
        Task<bool> Create(EditToRemainderCenterDto dto);
        Task<List<EditToRemainderCenterDto>> GetAllRemainderCenterAsync();
        Task<bool> UpdateRemainderCenterAsync(EditToRemainderCenterDto dto);
        Task<bool> CompleteRemainder(EditToRemainderCenterDto dto);
        Task<EditToRemainderCenterDto?> GetRemainderCenterByIdAsync(Guid? id);
        Task<bool> DeleteRemainderCenterAsync(Guid id);
        Task<bool> DeleteAllRemainderAsync();
        //Task<List<EditToClientDto>> SearchRemainderCenter(string searchTerm);

    }
}
