using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Client.Services
{
	public class CaseService
	{
		private readonly ICasesRepository _repository;

		public CaseService(ICasesRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<CaseType>> GetAllCaseType()
		{
			var newCaseType = await _repository.GetAllCaseTypeAsync();
			return newCaseType;
		}
		public async Task<List<CaseSubType>> GetAllCaseSubTypes(Guid CaseTypeId)
		{
			var newCaseSubType = await _repository.GetSubTypesByCaseTypeIdAsync(CaseTypeId);
			return newCaseSubType;
		}

	}
}
