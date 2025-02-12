using App.Domain.Core.Contract.Repository;
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

        public async Task Add(Client client)
		{
			_context.Clients.AddAsync(client);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var client = await Get(id);
			if (client != null)
			{
				_context.Clients.Remove(client);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Client> Get(int id)
		{
			return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Client>> GetAll()
		{
			return await _context.Clients.ToListAsync();
		}

		public async Task Update(int id, Client client)
		{
		     var clientToUpdate = await Get(id);
			if (clientToUpdate != null)
			{
				clientToUpdate.Email = client.Email;
				clientToUpdate.ProfilePicture = client.ProfilePicture;
				clientToUpdate.AddressId = client.AddressId;
				clientToUpdate.PhoneNumber  = client.PhoneNumber;
				clientToUpdate.AccountBalance = client.AccountBalance;
				clientToUpdate.FullName = client.FullName;
				clientToUpdate.Username = client.Username;
				await _context.SaveChangesAsync();
			}
		}
	}
}
