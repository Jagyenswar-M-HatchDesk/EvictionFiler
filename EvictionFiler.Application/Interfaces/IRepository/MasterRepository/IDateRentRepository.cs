using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IDateRentRepository : IRepository<DateRent>
    {
        Task<List<DateRent>> GetAllDateRent();
    }
}
