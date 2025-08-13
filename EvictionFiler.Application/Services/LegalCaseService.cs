using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Services
{
	public class LegalCaseService : ILegalCaseService
	{
		private readonly ICasesRepository _repository;
		public LegalCaseService(ICasesRepository repository)
		{
			_repository = repository;
		}

		public async Task<bool> AddLegalCasesAsync(CreateToEditLegalCaseModel dto)
		{
			var newcase = await _repository.AddCaseAsync(dto);
			return newcase;
		}

		public async Task<List<LegalCase>> GetAllAsync()
		{
			return await _repository.GetAllCasesAsync();
		}

		public async Task<CreateToEditLegalCaseModel?> GetByIdAsync(Guid id)
		{
			return await _repository.GetCaseByIdAsync(id);
		}
		public async Task<bool> UpdateAsync(CreateToEditLegalCaseModel dto)
		{
			// 2. Save Client
			var iscaseSaved = await _repository.UpdateCasesAsync(dto);
			return true;

		}

		public async Task DeleteAsync(Guid id)
		{
			await _repository.DeleteCaseAsync(id);
		}
	}
}
