namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IChatGptService
    {
        Task<string?> GenerateOSC(Guid CaseId);
        Task<string?> GenerateMotion(Guid CaseId);
    }
}
