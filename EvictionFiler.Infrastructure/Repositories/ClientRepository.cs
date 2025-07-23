using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
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
			return await _context.Clients
		 .Include(c => c.States)
		 .FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<List<CreateClientDto>> GetAllAsync()
		{
			var allclients = await _context.Clients
				.Include(client => client.States) 
				.Select(client => new CreateClientDto
				{
					Id = client.Id,
					ClientCode = client.ClientCode ?? "",
					FirstName = client.FirstName ?? "",
					LastName = client.LastName ?? "",
					Email = client.Email ?? "",
					Address_1 = client.Address_1 ?? "",
					Address_2 = client.Address_2 ?? "",
					City = client.City ?? "",
					StateName = client.States != null ? client.States.Name : "Unknown", 
					StateId = client.StateId,
					ZipCode = client.ZipCode ?? 0,
					Fax = client.Fax ?? "",
					Phone = client.Phone ?? "",
					CellPhone = client.CellPhone ?? "",
					IsActive = client.IsActive ?? false,
					IsDeleted = client.IsDeleted ?? false,
					CreatedAt = client.CreatedAt ?? DateTime.UtcNow,
					CreatedBy = client.CreatedBy ?? "Admin",
					UpdatedAt = client.UpdatedAt ?? DateTime.UtcNow,
					UpdatedBy = client.UpdatedBy ?? "Admin"
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
				ClientCode = await GenerateClientCodeAsync(),
				FirstName = client.FirstName,
				LastName = client.LastName,
				Email = client.Email,
				Address_1 = client.Address_1,
				Address_2 = client.Address_2,
				City = client.City,
				StateId = client.StateId,
				ZipCode = client.ZipCode,
				Phone = client.Phone,
				CellPhone = client.CellPhone,
				Fax = client.Fax,
				
				CreatedAt = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedBy = null,
				UpdatedBy = null,
				UpdatedAt = DateTime.Now,
			
			};

			_context.Clients.Add(newclient);
			var result = await _context.SaveChangesAsync();

			return result > 0;
		}

		public async Task<bool> UpdateClientAsync(EditClientDto client)
		{
			var existing = await _context.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
			if (existing == null) return false;


			existing.FirstName = client.FirstName;
			existing.LastName = client.LastName;
			existing.Email = client.Email;
			existing.Address_1 = client.Address_1;
			existing.Address_2 = client.Address_2;
			existing.City = client.City;
			existing.StateId = client.StateId;
			existing.ZipCode = client.ZipCode;
			existing.Phone = client.Phone;
			existing.CellPhone = client.CellPhone;
			existing.Fax = client.Fax;
			existing.CreatedAt = DateTime.Now;
			existing.IsActive = client.IsActive;
			existing.IsDeleted = client.IsDeleted;
			existing.CreatedBy = client.CreatedBy;
			existing.UpdatedBy = client.UpdatedBy;
			existing.UpdatedAt = DateTime.Now;
				



			_context.Clients.Update(existing);
			await _context.SaveChangesAsync();

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

		public async Task<List<State>> GetAllStateAsync()
		{
			return await _context.mst_State.ToListAsync();
		}

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
				StateId = e.StateId,
				ZipCode = e.ZipCode,
                Phone = e.Phone,
                CellPhone = e.CellPhone,
                Fax = e.Fax,
                //GenarateOwnRd = e.GenarateOwnRd,

            }).ToListAsync();
            if (client == null)
                return new List<CreateClientDto>();
            return client;
        }

		public async Task<string> GenerateClientCodeAsync()
		{
			// Get the latest case from DB
			var lastCase = await _context.Clients
				.OrderByDescending(c => c.ClientCode)
				.Select(c => c.ClientCode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("CC"))
			{
				string numberPart = lastCase.Substring(2); // Remove 'EF'
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			// Generate new CaseCode
			string newCode = "CC" + nextNumber.ToString("D10"); // D10 = 10 digits
			return newCode;
		}
	}

}
