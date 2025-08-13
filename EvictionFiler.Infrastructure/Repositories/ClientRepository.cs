using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IRepository;
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
			return await _context.MstStates.ToListAsync();
		}

		public async Task<Client?> GetClientWithAllDetailsAsync(Guid clientId)
		{
			return await _context.Clients
				.Where(c => c.Id == clientId && c.IsDeleted != true)
				.Include(c => c.LandLords)
					.ThenInclude(l => l.Buildings)
						.ThenInclude(b => b.Tenants)
				.FirstOrDefaultAsync();
		}

		public async Task<List<CreateToClientDto>> SearchClientByCode(string code)
        {
            var client = await _context.Clients.Where(e => e.ClientCode.Contains(code)).Select(e => new CreateToClientDto
            {
              
                ClientCode = e.ClientCode,
                FirstName = e.FirstName,
                Email = e.Email,
                Address1 = e.Address1,
                Address2= e.Address2,
                City = e.City,
				StateId = e.StateId,
				ZipCode = e.ZipCode,
                Phone = e.Phone,
                CellPhone = e.CellPhone,
                Fax = e.Fax,

            }).ToListAsync();
            if (client == null)
                return new List<CreateToClientDto>();
            return client;
        }

		public async Task<string> GenerateClientCodeAsync()
		{
			var lastCase = await _context.Clients
				.OrderByDescending(c => c.ClientCode)
				.Select(c => c.ClientCode)
				.FirstOrDefaultAsync();

			int nextNumber = 1;

			if (!string.IsNullOrEmpty(lastCase) && lastCase.StartsWith("CC"))
			{
				string numberPart = lastCase.Substring(2);
				if (int.TryParse(numberPart, out int parsedNumber))
				{
					nextNumber = parsedNumber + 1;
				}
			}

			string newCode = "CC" + nextNumber.ToString("D10"); // D10 = 10 digits
			return newCode;
		}
	}

}
