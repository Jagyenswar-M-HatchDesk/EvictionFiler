using EvictionFiler.Application.DTOs.CourtDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;

namespace EvictionFiler.Application.Services
{
    public class CourtService:ICourtService
    {
        private readonly ICourtRepository _courtRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourtService(ICourtRepository courtRepository, IUnitOfWork unitOfWork)
        {
            _courtRepository = courtRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<List<CourtDto>> GetAllCourtDataAsync()
        {
            //    return await _courtRepository.GetAllCourtDataAsync();

            var courts = await _courtRepository.GetAllCourtDataAsync(); // returns List<CourtInfos>

            // map entities to DTOs
            var courtDtos = courts.Select(c => new CourtDto
            {

                Id = c.Id,
                Court = c.Court,
                Address = c.Address,
                Phone = c.Phone,
                Notes = c.Notes,
                CallIn = c.CallIn,
                ConferenceId = c.ConferenceId,
                RoomNo = c.RoomNo,
                Judge = c.Judge,
                Part = c.Part,
                VirtualLink = c.VirtualLink,
                
            }).ToList();

            return courtDtos;
        }

        public async Task<PaginationDto<CourtDto>> GetAllCourtsAsync(
    int pageNumber,
    int pageSize,
    string searchTerm,
    string userId,
    bool isAdmin)
        {
            // Since your repository doesn't filter by user yet, we’ll ignore userId and isAdmin for now
            var result = await _courtRepository.GetPagedCourtsAsync(pageNumber, pageSize, searchTerm);

            var dtoList = result.Items.Select(c => new CourtDto
            {
                Id = c.Id,
                Court = c.Court,
                Address = c.Address,
                Phone = c.Phone,
                Notes = c.Notes,
                CallIn = c.CallIn,
                ConferenceId = c.ConferenceId,
                RoomNo = c.RoomNo,
                Judge = c.Judge,
                Part = c.Part,
                VirtualLink = c.VirtualLink,

            }).ToList();

            return new PaginationDto<CourtDto>
            {
                Items = dtoList,
                TotalCount = result.TotalCount
            };
        }


        //    public async Task<PaginationDto<CourtInfosDto>> GetAllCourtsDataAsync(
        //int pageNumber,
        //int pageSize,
        //string searchTerm,
        //string userId,
        //bool isAdmin)
        //    {
        //        var query = _courtRepository.GetAllQuerable(x => x.IsDeleted != true, x => x.State);

        //        // Filter by user if not admin
        //        if (!isAdmin && Guid.TryParse(userId, out Guid userGuid))
        //        {
        //            query = query.Where(x => x.CreatedBy == userGuid);
        //        }

        //        // Search filter
        //        if (!string.IsNullOrWhiteSpace(searchTerm))
        //        {
        //            query = query.Where(x =>
        //                x.Court.Contains(searchTerm) ||
        //                x.Address.Contains(searchTerm) ||
        //                x.Phone.Contains(searchTerm) ||
        //                x.Notes.Contains(searchTerm));
        //        }

        //        var totalCount = await query.CountAsync();

        //        var courts = await query
        //            .OrderBy(x => x.Court)
        //            .Skip((pageNumber - 1) * pageSize)
        //            .Take(pageSize)
        //            .ToListAsync();

        //        // Map to DTO
        //        var courtDtos = courts.Select(c => new CourtInfosDto
        //        {
        //            Id = c.Id,
        //            Court = c.Court,
        //            Address = c.Address,
        //            Phone = c.Phone,
        //            Notes = c.Notes

        //        }).ToList();

        //        return new PaginationDto<CourtInfosDto>
        //        {
        //            Items = courtDtos,
        //            TotalCount = totalCount
        //        };
        //    }

        public async Task<Guid?> AddCourtAsync(CourtDto courtInfosDto)
        {
            return await _courtRepository.AddCourtAsync(courtInfosDto);



        }
        public async Task<CourtDto> GetCourtByIdAsync(Guid id)
        {
            var court = await _courtRepository.GetCourtByIdAsync(id);
            if (court == null) return null;
            return new CourtDto
            {
                Id = court.Id,
                Court = court.Court,
                Address = court.Address,
                Phone = court.Phone,
                Notes = court.Notes,
                RoomNo = court.RoomNo,
                Judge = court.Judge,
                VirtualLink = court.VirtualLink,
                ConferenceId = court.ConferenceId,
                CallIn = court.CallIn,
                Part = court.Part,
            };
        }
        public async Task UpdateCourtAsync(CourtDto dto)
        {
            await _courtRepository.UpdateCourtAsync(dto);
        }
        public async Task DeleteCourtAsync(Guid id)
        {
            await _courtRepository.DeleteCourtAsync(id);
        }
    }
}
