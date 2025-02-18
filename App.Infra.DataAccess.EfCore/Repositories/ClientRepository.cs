using App.Domain.Core.Contract.Repository;
using App.Domain.Core.DTOs.ClientDto;
using App.Domain.Core.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Repositories
{
    public class ClientRepository : IClientRepository
	{
		private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(CreateClientDto client,CancellationToken cancellation)
		{
			var newClient = new Client
			{
				FullName = client.FullName,
				//Email = client.Email,
				//UserName = client.Username,
				//PasswordHash = client.Password,
				PhoneNumber = client.PhoneNumber,
				Gender = client.Gender
			};
			await _context.Clients.AddAsync(newClient,cancellation);
			await _context.SaveChangesAsync(cancellation);
		}

		public async Task Delete(int id,CancellationToken cancellation)
		{
			var client = await _context.Clients.FindAsync(id, cancellation);
			if (client != null)
			{
				_context.Clients.Remove(client);
				await _context.SaveChangesAsync(cancellation);
			}
		}

		public async Task<Client> Get(int id,CancellationToken cancellation)
		{
			return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id, cancellation);
		}

		public async Task<List<Client>> GetAll(CancellationToken cancellation)
		{
			return await _context.Clients.ToListAsync(cancellation);
		}

        public async Task<Client> GetClientInfo(int id, CancellationToken cancellation)
        {
            return await _context.Clients
				.Include(x => x.AppUser)
				.Include(x => x.ServiceRequests)
				.FirstAsync(x => x.Id == id);
        }

        public async Task Update(UpdateClientDto client,CancellationToken cancellation)
		{
		    var clientToUpdate = await _context.Clients.FindAsync(client.Id, cancellation);
			if (clientToUpdate != null)
			{
				//clientToUpdate.Email = client.Email;
				clientToUpdate.PhoneNumber  = client.PhoneNumber;
				clientToUpdate.FullName = client.FullName;
				//clientToUpdate.UserName = client.Username;
				await _context.SaveChangesAsync();
			}
		}
	}
}
