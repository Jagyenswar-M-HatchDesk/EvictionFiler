using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IRenewalStatusRepository : IRepository<RenewalStatus>
    {
        Task<List<RenewalStatus>> GetAllRenewalStatus();
    }
}
