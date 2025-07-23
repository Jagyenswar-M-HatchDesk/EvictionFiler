using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Services
{
	public class CaseService : ICaseService
	{
		private readonly ICasesRepository _repository;

		public CaseService(ICasesRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<CaseType>> GetAllCaseType()
		{
			var newCaseType = await _repository.GetAllCaseTypeAsync();
			return newCaseType;
		}
		public async Task<List<CaseSubType>> GetAllCaseSubTypes(Guid CaseTypeId)
		{
			var newCaseSubType = await _repository.GetSubTypesByCaseTypeIdAsync(CaseTypeId);
			return newCaseSubType;
		}

		public async Task<List<ClientRole>> GetAllClientRole()
		{
			var roles = await _repository.GetAllClientRole();
			return roles;
		}
	}
}
