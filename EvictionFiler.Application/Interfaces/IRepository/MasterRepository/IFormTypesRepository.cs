using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface IFormTypesRepository
	{
		Task<List<FormTypes>> GetAllFormTYpes();
		Task<List<FormAddEditViewModelDto>> GetFormTypesByCaseTypeAsync(Guid? caseTypeId);

    }
}
