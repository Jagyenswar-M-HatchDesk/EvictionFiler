using EvictionFiler.Application.DTOs.FirmDtos;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IFirmRepository : IRepository<Firms>
    {
        Task<Guid?> RegisterFirm(FirmDto dto);
    }
}
