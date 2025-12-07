//using EvictionFiler.Domain.Entities;
using EvictionFiler.Application.DTOs.MarshalsDto;
using Marshal = EvictionFiler.Domain.Entities.Marshal;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IMarshalRepositroy
    {
        Task<Marshal> GetMarshalByIdAsync(Guid id);
        Task<IEnumerable<Marshal>> GetAllMarshalAsync();

        Task<Marshal> AddMarshalAsync(Marshal marshal);
        Task<Marshal> UpdateMarshalAsync(Marshal marshal);
        Task<bool> DeleteMarshalAsync(Guid id);
        Task<List<MarshalDto>> SearchMarshalbyname(string name);
    }
}
