using EvictionFiler.Application.DTOs;
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

        public async Task<LegalCase?> GetByIdAsync(Guid id)
        {
            return await _repository.GetCaseByIdAsync(id);
        }

        

        //public async Task UpdateAsync(CreateEditLegalCaseModel model)
        //{
        //    if (model.Id == null) return;

        //    var entity = await _repository.GetCaseByIdAsync(model.Id.Value);
        //    if (entity != null)
        //    {
        //        entity.ClientId = model.ClientId;
        //        entity.ApartmentId = model.ApartmentId;
        //        entity.LandLordId = model.LandLordId;
        //        entity.CaseName = model.CaseName;

        //        await _repository.UpdateCaseAsync(entity);
        //    }
        //}

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteCaseAsync(id);
        }
    }
}
