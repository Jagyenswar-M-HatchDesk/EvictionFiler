using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public interface IMarshalAndWarrantRepository 
    {
        Task<MarshalAndWarrantDetailDto> GetMarshalDetailAsync(Guid caseId);
    }
}
