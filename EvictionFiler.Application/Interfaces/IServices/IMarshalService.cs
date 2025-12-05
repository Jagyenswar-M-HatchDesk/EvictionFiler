using EvictionFiler.Application.DTOs.MarshalsDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IMarshalService
    {
        Task<MarshalDto> GetMarshalByIdAsync(Guid id);
        Task<IEnumerable<MarshalDto>> GetAllMarshalAsync();
        Task<MarshalDto> CreateMarshalAsync(MarshalDto marshal);
        Task<MarshalDto> UpdateMarshalAsync(MarshalDto marshal);

        Task<bool> DeleteMarshalAsync(Guid id);
        Task<List<MarshalDto>> SearchMarshalbyname(string name);
    }
}
