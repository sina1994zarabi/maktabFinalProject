using App.Domain.Core.Contract.Repository;
using App.Domain.Core.DTOs.ServiceDto;
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

        public async Task Add(CreateServiceDto service)
		{
			var newService = new Service
			{
				Title = service.Title,
				Description = service.Description,
				Price = service.Price,
				SubCategoryId = service.SubCategoryId,
			};
			await _context.Services.AddAsync(newService);
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

		public async Task Update(UpdateServiceDto service)
		{
			var serviceToEdit = await Get(service.Id);
			if (serviceToEdit != null)
			{
				serviceToEdit.Title = service.Title;
				serviceToEdit.Description = service.Description;
				serviceToEdit.Price = service.Price;
				serviceToEdit.SubCategoryId = service.SubCategoryId;
				await _context.SaveChangesAsync();
			}
		}
	}
}
