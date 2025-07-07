
﻿using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;


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

        public async Task<List<CreateClientDto>> GetAllAsync()
        {
            var allclients = await _context.Clients.Select(client => new CreateClientDto
            {
                Id = client.Id,
                ClientCode = client.ClientCode ?? "",
                FirstName = client.FirstName ?? "",
                LastName = client.LastName ?? "",
                Email = client.Email ?? "",
                Address_1 = client.Address_1 ?? "",
                Address_2 = client.Address_2 ?? "",
                City = client.City ?? "",
                State = client.State ?? "",
                ZipCode = client.ZipCode ?? 0,
                Fax = client.Fax ?? "",
                Phone = client.Phone ?? "",
                CellPhone = client.CellPhone ?? "",
                GenarateOwnRd = client.GenarateOwnRd ?? false
            }).ToListAsync();

            return allclients ?? new List<CreateClientDto>();
        }
	

		public async Task<bool> AddAsync(CreateClientDto client)
		{
			// Make sure Id is provided
			if (client.Id == Guid.Empty)
				client.Id = Guid.NewGuid(); 

			var newclient = new Client
			{
				Id = client.Id, 
				ClientCode = client.ClientCode,
				FirstName = client.FirstName,
				LastName = client.LastName,
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
				IsActive = true
			};

			_context.Clients.Add(newclient);
			var result = await _context.SaveChangesAsync();

			return result > 0;
		}


		public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

		public async Task<bool> DeleteAsync(Guid id)
		{
			var client = await _context.Clients.FindAsync(id);
			if (client != null)
			{
				_context.Clients.Remove(client);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}




	

        //public Task AddAsync(Client client)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<CreateClientDto>> SearchClientByCode(string code)
        {
            var client = await _context.Clients.Where(e => e.ClientCode.Contains(code)).Select(e => new CreateClientDto
            {

                Id = e.Id,
                ClientCode = e.ClientCode,
                FirstName = e.FirstName,
                Email = e.Email,
                Address_1 = e.Address_1,
                Address_2 = e.Address_2,
                City = e.City,
                State = e.State,
                ZipCode = e.ZipCode,
                Phone = e.Phone,
                CellPhone = e.CellPhone,
                Fax = e.Fax,
                GenarateOwnRd = e.GenarateOwnRd,

            }).ToListAsync();
            if (client == null)
                return new List<CreateClientDto>();
            return client;
        }

        public static string GenerateCaseCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
