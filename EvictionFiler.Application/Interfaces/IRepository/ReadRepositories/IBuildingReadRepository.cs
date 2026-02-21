using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public  interface IBuildingReadRepository : IReadRepository<Building>
    {

        Task<BuildingDetailDto> GetBuildingDetailAsync(Guid caseId);
    }
}
