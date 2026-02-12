using EvictionFiler.Application.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
   public interface IRegisterService
    {
        Task<(bool Success, string Message)> RegisterAsync(RegisterDto dto);
    }
}
