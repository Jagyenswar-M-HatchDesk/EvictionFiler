using EvictionFiler.Application.DTOs.ClientDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IClientService
    {
        Task<bool> AddClientAsync(CreateClientDto client);
    }
}
