using EvictionFiler.Application.DTOs.MarshalsDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Services
{
    public class MarshalService : IMarshalService
    {
        private readonly IMarshalRepositroy _marshalRepo;

        public MarshalService(IMarshalRepositroy marshalRepo)
        {
            _marshalRepo = marshalRepo;
        }
        public async Task<MarshalDto> GetMarshalByIdAsync(Guid id)
        {
            var entity = await _marshalRepo.GetMarshalByIdAsync(id);
            if (entity == null)
                return null;

            return new MarshalDto
            {
                Id = entity.Id,
                Name = entity.Name,
                BadgeNumber = entity.BadgeNumber,
                Telephone = entity.Telephone,
                Fax = entity.Fax,
                OfficeAddress = entity.OfficeAddress
            };

        }

        public async Task<IEnumerable<MarshalDto>> GetAllMarshalAsync()
        {
            var entities = await _marshalRepo.GetAllMarshalAsync();

            return entities.Select(e => new MarshalDto
            {
                Id = e.Id,
                Name = e.Name,
                BadgeNumber = e.BadgeNumber,
                Telephone = e.Telephone,
                Fax = e.Fax,
                OfficeAddress = e.OfficeAddress
            });
        }

        public async Task<MarshalDto> CreateMarshalAsync(MarshalDto dto)
        {
            var entity = new Marshal
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                BadgeNumber = dto.BadgeNumber,
                Telephone = dto.Telephone,
                Fax = dto.Fax,
                OfficeAddress = dto.OfficeAddress
            };

            var saved = await _marshalRepo.AddMarshalAsync(entity);

            return new MarshalDto
            {
                Id = saved.Id,
                Name = saved.Name,
                BadgeNumber = saved.BadgeNumber,
                Telephone = saved.Telephone,
                Fax = saved.Fax,
                OfficeAddress = saved.OfficeAddress
            };
        }
        public async Task<MarshalDto> UpdateMarshalAsync(MarshalDto dto)
        {
            var entity = new Marshal
            {
                Id = dto.Id,
                Name = dto.Name,
                BadgeNumber = dto.BadgeNumber,
                Telephone = dto.Telephone,
                Fax = dto.Fax,
                OfficeAddress = dto.OfficeAddress
            };

            var updated = await _marshalRepo.UpdateMarshalAsync(entity);

            return new MarshalDto
            {
                Id = updated.Id,
                Name = updated.Name,
                BadgeNumber = updated.BadgeNumber,
                Telephone = updated.Telephone,
                Fax = updated.Fax,
                OfficeAddress = updated.OfficeAddress
            };
        }

        public async Task<bool> DeleteMarshalAsync(Guid id)
        {
            return await _marshalRepo.DeleteMarshalAsync(id);
        }


    }
}
