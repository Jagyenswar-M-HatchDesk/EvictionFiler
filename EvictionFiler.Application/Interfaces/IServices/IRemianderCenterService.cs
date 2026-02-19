using EvictionFiler.Application.DTOs.RemainderCenterDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IRemianderCenterService
    {
        Task<bool> Create(CreateToRemainderCenterDto dto);
        Task<List<EditToRemainderCenterDto>> GetAllRemainderCenterAsync();
        Task<bool> UpdateRemainderCenterAsync(EditToRemainderCenterDto dto);
        Task<bool> CompleteRemainder(EditToRemainderCenterDto dto);
        Task<EditToRemainderCenterDto?> GetRemainderCenterByIdAsync(Guid? id);
        Task<bool> DeleteRemainderCenterAsync(Guid id);
        Task<bool> DeleteAllRemainderAsync();
        Task<List<EditToRemainderCenterDto?>> GetRemainderCenterByCaseIdAsync(Guid? CaseId);
        //Task<List<EditToClientDto>> SearchRemainderCenter(string searchTerm);
        Task CreateNewReminder(Guid caseId, string Description, DateTime Date);
        Task<List<EditToRemainderCenterDto>?> GetAllInCompleteRemainder(bool isSuperAdmin,Guid? userId = null);
    }
}
