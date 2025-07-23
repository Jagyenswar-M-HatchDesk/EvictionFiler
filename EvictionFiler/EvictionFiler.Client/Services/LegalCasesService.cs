using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.Repositories;

namespace EvictionFiler.Client.Services
{
    public class LegalCasesService 
    {
        private readonly ICasesRepository _repository;
        public LegalCasesService(ICasesRepository repository)
        { 
            _repository = repository;
        }

        public async Task<bool> AddLegalCasesAsync(CreateEditLegalCaseModel dto)
        {
            var newcase = await _repository.AddCaseAsync(dto);
            return newcase;
        }

        public async Task<List<LegalCase>> GetAllAsync()
        {
            return await _repository.GetAllCasesAsync();
        }

        public async Task<CreateEditLegalCaseModel?> GetByIdAsync(Guid id)
        {
            return await _repository.GetCaseByIdAsync(id);
        }



    

		public async Task<bool> UpdateAsync(CreateEditLegalCaseModel dto)
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
