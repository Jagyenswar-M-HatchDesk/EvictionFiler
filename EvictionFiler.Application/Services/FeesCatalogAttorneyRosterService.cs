using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IServices.Master;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services.Master
{
    public class FeesCatalogAttorneyRosterService : IFeesCatalogAttorneyRosterService
    {
        private readonly IFeesCatalogAttorneyRosterRepository _repository;

        public FeesCatalogAttorneyRosterService(IFeesCatalogAttorneyRosterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FeesCatalogAttorneyRosterDto>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<FeesCatalogAttorneyRoster?> GetByIdAsync(Guid id) =>
            await _repository.GetByIdAsync(id);

        public async Task<Guid?> AddAsync(FeesCatalogAttorneyRoster entity)
        {
            return await _repository.AddAsync(entity);
        }
        //public async Task<int> AddAsync(FeesCatalogAttorneyRoster entity)
        //{
        //    return await _repository.AddAsync(entity);
        //}

        public async Task<bool> UpdateAsync(FeesCatalogAttorneyRosterDto entity)
        {

            return await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }
}

