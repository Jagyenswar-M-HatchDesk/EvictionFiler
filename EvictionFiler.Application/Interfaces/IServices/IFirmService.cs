using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IFirmService
    {
        Task<IEnumerable<FirmDto>> GetAllFirms();
        Task<bool> AddNewFirm(FirmDto dto);
        Task<bool> RegisterFirm(RegisterDto model, FirmDto dto);
    }
}
