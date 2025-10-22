
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IServices.Master;
using EvictionFiler.Domain.Entities;
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

        public async Task<List<FeesCatalogAttorneyRoster>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<FeesCatalogAttorneyRoster?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddAsync(FeesCatalogAttorneyRoster entity) =>
            await _repository.AddAsync(entity);

        public async Task UpdateAsync(FeesCatalogAttorneyRoster entity) =>
            await _repository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
