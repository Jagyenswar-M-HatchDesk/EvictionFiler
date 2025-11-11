using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
	public interface ICaseFormRepository :  IRepository<CaseForms>
	{
		Task<bool> GenerateNoticeAsync(Guid legalCaseId, Guid formTypeId, Guid createdBy);
		//Task<byte[]> GetPdfBytesAsync(Guid id);

        //Task<bool> GetCaseForms(Guid legalCaseId, Guid formTypeId, Guid createdBy);
    }
}
