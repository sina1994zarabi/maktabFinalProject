using App.Domain.Core.Contract.Repository;
using App.Domain.Core.DTOs.Client;
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

        public async Task Add(CreateClientDto client)
		{
			var newClient = new Client
			{
				FullName = client.FullName,
				Email = client.Email,
				Username = client.Username,
				//Password = client.Password,
				PhoneNumber = client.PhoneNumber,
				Gender = client.Gender
			};
			await _context.Clients.AddAsync(newClient);
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

		public async Task Update(UpdateClientDto client)
		{
		    var clientToUpdate = await Get(client.Id);
			if (clientToUpdate != null)
			{
				clientToUpdate.Email = client.Email;
				clientToUpdate.PhoneNumber  = client.PhoneNumber;
				clientToUpdate.FullName = client.FullName;
				clientToUpdate.Username = client.Username;
				await _context.SaveChangesAsync();
			}
		}
	}
}
