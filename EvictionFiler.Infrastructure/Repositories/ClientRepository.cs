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

		public async Task<List<EditToClientDto>> SearchClient(string searchTerm)
		{
			if (string.IsNullOrWhiteSpace(searchTerm))
				return new List<EditToClientDto>();

			searchTerm = searchTerm.Trim().ToLower();

			var testclient = _context.Clients.ToList();

			var client = await _context.Clients
				.Where(e =>
					(e.ClientCode != null && e.ClientCode.ToLower().Contains(searchTerm)) ||
					(e.FirstName != null && e.FirstName.ToLower().Contains(searchTerm)) ||
					(e.LastName != null && e.LastName.ToLower().Contains(searchTerm)) ||
					(e.Email != null && e.Email.ToLower().Contains(searchTerm)) ||
					(e.Phone != null && e.Phone.ToLower().Contains(searchTerm)) ||
					(e.CellPhone != null && e.CellPhone.ToLower().Contains(searchTerm)) ||
					(e.Fax != null && e.Fax.ToLower().Contains(searchTerm)) ||
					(e.Address1 != null && e.Address1.ToLower().Contains(searchTerm)) ||
					(e.Address2 != null && e.Address2.ToLower().Contains(searchTerm)) ||
					(e.City != null && e.City.ToLower().Contains(searchTerm)) ||
					  (e.IsActive ? "active" : "inactive").Contains(searchTerm)
				)
				.Select(e => new EditToClientDto
                {
					Id = e.Id,
					ClientCode = e.ClientCode,
					FirstName = e.FirstName,
					LastName = e.LastName,
					Email = e.Email,
					Address1 = e.Address1,
					Address2 = e.Address2,
					City = e.City,
					StateId = e.StateId,
					ZipCode = e.ZipCode,
					Phone = e.Phone,
					CellPhone = e.CellPhone,
					Fax = e.Fax,
					Status = e.IsActive ,
					ClientTypeId = e.ClientTypeId,
					Reference = e.Reference,
				})
				.ToListAsync();

			return client ?? new List<EditToClientDto>();
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

        public async Task<bool> IsEmailExists(string email)
        {
            return await _context.Clients
                       .AnyAsync(c => c.Email.ToLower() == email.ToLower());
        }
    }

}
