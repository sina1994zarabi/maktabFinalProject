using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Repositories
{
	public class ServiceRepository : IServiceRepository
	{
		private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(Service service)
		{
			_context.Services.Add(service);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var serviceToDelete = await Get(id);
			if (serviceToDelete != null)
			{
				_context.Services.Remove(serviceToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Service> Get(int id)
		{
			return await _context.Services.FindAsync(id);
		}

		public async Task<List<Service>> GetAll()
		{
			return await _context.Services.ToListAsync();
		}

		public async Task Update(int id, Service service)
		{
			var serviceToEdit = await Get(id);
			if (serviceToEdit != null)
			{
				serviceToEdit.Title = service.Title;
				serviceToEdit.Description = service.Description;
				serviceToEdit.Price = service.Price;
				await _context.SaveChangesAsync();
			}
		}
	}
}
