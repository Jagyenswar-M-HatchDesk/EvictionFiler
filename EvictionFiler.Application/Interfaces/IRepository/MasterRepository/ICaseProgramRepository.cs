using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface ICaseProgramRepository
    {
        Task<List<CaseProgram>> GetAllCaseProgram();
    }
}
