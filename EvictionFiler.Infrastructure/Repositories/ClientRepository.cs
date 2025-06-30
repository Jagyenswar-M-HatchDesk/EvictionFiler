using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvictionFiler.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MainDbContext _context;

        public ClientRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var allclients = await _context.Clients.ToListAsync();
            return allclients;
        }

        public async Task<bool> AddAsync(CreateClientDto client)
        {
            var newclient = new Client
            {
                Id = Guid.NewGuid(),
                ClientCode = client.ClientCode,
                Name = client.Name,
                Email = client.Email,
                Address_1 = client.Address_1,
                Address_2 = client.Address_2,
                City = client.City,
                State = client.State,
                ZipCode = client.ZipCode,
                Phone = client.Phone,
                CellPhone = client.CellPhone,
                Fax = client.Fax,
                GenarateOwnRd = client.GenarateOwnRd,
                CreatedAt = DateTime.Now,
                IsActive = true,

            };
            _context.Clients.Add(newclient);
            var result = await _context.SaveChangesAsync();

            if(result !=null )
            {
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        //public Task AddAsync(Client client)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
