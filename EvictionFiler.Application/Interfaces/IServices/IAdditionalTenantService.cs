using EvictionFiler.Application.DTOs.TenantDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IAdditionalTenantService
    {
        Task AddAdditionalTenantAsync(List<AddtionalTenantDto> tenant);
    }
}
