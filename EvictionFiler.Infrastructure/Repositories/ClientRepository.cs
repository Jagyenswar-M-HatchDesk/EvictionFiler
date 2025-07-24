using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;


namespace EvictionFiler.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>,  IClientRepository
    {
        private readonly MainDbContext _context;

        public ClientRepository(MainDbContext context) : base(context)
		{
            _context = context;
        }

		public async Task<List<State>> GetAllStateAsync()
		{
			return await _context.mst_State.ToListAsync();
		}

		public async Task<Client?> GetClientWithAllDetailsAsync(Guid clientId)
		{
			return await _context.Clients
				.Where(c => c.Id == clientId && c.IsDeleted != true)
				.Include(c => c.LandLords)
				.Include(c => c.Tenants)
				.Include(c => c.Appartments)
				.FirstOrDefaultAsync();
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
