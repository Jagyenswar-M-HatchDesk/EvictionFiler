using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IClientRepository : IRepository<Client>
	{

        Task<List<State>> GetAllStateAsync();

        Task<List<CreateClientDto>> SearchClientByCode(string code);
        Task<string> GenerateClientCodeAsync();
    

	}
}
