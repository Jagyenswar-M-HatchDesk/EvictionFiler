using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public interface ICaseHearingReadRepository:IReadRepository<CaseHearing>

    {

        Task<int> GetAllTodayCaseHearingAsync(Guid? firmId, bool isAdmin);
    }
}
