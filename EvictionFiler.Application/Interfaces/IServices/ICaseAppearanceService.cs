using EvictionFiler.Application.DTOs.CaseAppearanceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICaseAppearanceService
    {
        Task<bool> AddCaseAppearance(CaseAppearanceDto data);
    }
}
