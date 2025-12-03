using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.RemainderCenterDto;
using EvictionFiler.Domain.Entities.Master;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface IRemianderCenterService
    {
		Task<bool> Create(EditToRemainderCenterDto dto);
		Task<List<EditToRemainderCenterDto>> GetAllRemainderCenterAsync();
		Task<bool> UpdateRemainderCenterAsync(EditToRemainderCenterDto dto);

		Task<EditToRemainderCenterDto?> GetRemainderCenterByIdAsync(Guid? id);
		Task<bool> DeleteRemainderCenterAsync(Guid id);
		//Task<List<EditToClientDto>> SearchRemainderCenter(string searchTerm);
		
        }
}
