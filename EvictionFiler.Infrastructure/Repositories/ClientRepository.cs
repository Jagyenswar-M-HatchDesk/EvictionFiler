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

        public async Task<List<Client>> GetAllAsync()
        {
            var allclients = await _context.Clients.ToListAsync();
            return allclients;
        }
		public async Task<bool> AddAsync(CreateClientDto client)
		{
			//  Client 
			var newclient = new Client
			{
				Id = Guid.NewGuid(),
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

			//  Landlord 
			if (client.LandLord != null)
			{
				var landlordDto = client.LandLord;

				var landlord = new LandLord
				{
					Id = Guid.NewGuid(),
					Name = landlordDto.Name,
					EINorSSN = landlordDto.EINorSSN,
					Phone = landlordDto.Phone,
					Email = landlordDto.Email,
					MaillingAddress = landlordDto.MaillingAddress,
					Attorney = landlordDto.Attorney,
					Firm = landlordDto.Firm,
					ClientId = newclient.Id,
					CreatedAt = DateTime.Now,
					IsActive = true
				};

				_context.LandLords.Add(landlord);
				await _context.SaveChangesAsync();
			}

			//  Apartment
			if (client.Apartment != null)
			{
				var apartmentDto = client.Apartment;

				var apartment = new Appartment
				{
					Id = Guid.NewGuid(),
					ApartmentCode = apartmentDto.ApartmentCode,
					PremiseType = apartmentDto.PremiseType,
					Address_1 = apartmentDto.Address_1,
					Address_2 = apartmentDto.Address_2,
					City = apartmentDto.City,
					State = apartmentDto.State,
					Country = apartmentDto.Country,
					Zipcode = apartmentDto.Zipcode,
					MDR_Number = apartmentDto.MDR_Number,
					PetitionerInterest = apartmentDto.PetitionerInterest,
					ClientId = newclient.Id,
					CreatedAt = DateTime.Now,
					IsActive = true
				};

				_context.Appartments.Add(apartment);
				await _context.SaveChangesAsync();
			}

			return true;
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



	}
}
