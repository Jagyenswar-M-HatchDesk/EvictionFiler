using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IChatGptService
    {
        Task<string?> GenerateOSC(Guid CaseId);
        Task<string?> GenerateMotion(Guid CaseId);
    }
}
