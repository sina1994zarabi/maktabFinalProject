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
	public class ServiceProviderRepository : IServiceProviderRepository
	{
		private readonly AppDbContext _context;

        public ServiceProviderRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(ServiceProvider serviceProvider)
		{
			_context.ServiceProviders.Add(serviceProvider);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var serviceProviderToDelete = await Get(id);
			if (serviceProviderToDelete != null)
			{
				_context.ServiceProviders.Remove(serviceProviderToDelete);
				await _context.SaveChangesAsync();
			}

		}

		public async Task<ServiceProvider> Get(int id)
		{
			return await _context.ServiceProviders.FindAsync(id);
		}

		public async Task<List<ServiceProvider>> GetAll()
		{
			return await _context.ServiceProviders.ToListAsync();
		}

		public async Task Update(int id, ServiceProvider serviceProvider)
		{
			var serviceProviderToEdit = await Get(id);
			if (serviceProviderToEdit != null)
			{
				serviceProviderToEdit.Username = serviceProvider.Username;
				serviceProviderToEdit.Email = serviceProvider.Email;
				serviceProviderToEdit.ProfilePicture = serviceProvider.ProfilePicture;
				serviceProviderToEdit.AddressId = serviceProvider.AddressId;
				serviceProviderToEdit.PhoneNumber = serviceProvider.PhoneNumber;
				serviceProviderToEdit.AccountBalance = serviceProvider.AccountBalance;
				serviceProviderToEdit.FullName = serviceProvider.FullName;
				await _context.SaveChangesAsync();
			}
		}
	}
}
