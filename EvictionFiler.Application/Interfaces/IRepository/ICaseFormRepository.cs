using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
	public interface ICaseFormRepository :  IRepository<CaseForms>
	{
		Task<string?> GenerateNoticeAsync(Guid legalCaseId, Guid formTypeId, Guid createdBy);
		Task<bool> GenerateWarrantNoticeAsync(Guid legalCaseId, string formTypeName, Guid createdBy);
		//Task<byte[]> GetPdfBytesAsync(Guid id);

        //Task<bool> GetCaseForms(Guid legalCaseId, Guid formTypeId, Guid createdBy);
    }
}
