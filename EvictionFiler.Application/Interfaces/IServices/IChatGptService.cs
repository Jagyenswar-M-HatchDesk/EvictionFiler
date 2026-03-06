using EvictionFiler.Application.DTOs.GeneratedResposeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IChatGptService
    {
        Task<GeneratedContentResponseDto> GenerateOSC(Guid CaseId, string prompt);
        Task<GeneratedContentResponseDto> GenerateMotion(Guid CaseId, string prompt);
        Task<GeneratedContentResponseDto> GenerateOpposition(Guid CaseId, string prompt);
        Task<GeneratedContentResponseDto> GenerateReply(Guid CaseId, string prompt);

    }
}
