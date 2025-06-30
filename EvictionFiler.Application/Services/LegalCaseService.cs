using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;

using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Services
{
    public class LegalCaseService : ILegalCaseService
    {
        private readonly ICasesRepository _repository;

        public LegalCaseService(ICasesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LegalCase>> GetAllAsync()
        {
            return await _repository.GetAllCasesAsync();
        }

        public async Task<LegalCase?> GetByIdAsync(Guid id)
        {
            return await _repository.GetCaseByIdAsync(id);
        }

        public async Task CreateAsync(CreateEditLegalCaseModel model)
        {
            var entity = new LegalCase
            {
                Id = Guid.NewGuid(),
                ClientId = model.ClientId,
                ApartmentId = model.ApartmentId,
                LandLordId = model.LandLordId,
                CaseName = model.CaseName
            };

            await _repository.AddCaseAsync(entity);
        }

        public async Task UpdateAsync(CreateEditLegalCaseModel model)
        {
            if (model.Id == null) return;

            var entity = await _repository.GetCaseByIdAsync(model.Id.Value);
            if (entity != null)
            {
                entity.ClientId = model.ClientId;
                entity.ApartmentId = model.ApartmentId;
                entity.LandLordId = model.LandLordId;
                entity.CaseName = model.CaseName;

                await _repository.UpdateCaseAsync(entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteCaseAsync(id);
        }
    }
}
