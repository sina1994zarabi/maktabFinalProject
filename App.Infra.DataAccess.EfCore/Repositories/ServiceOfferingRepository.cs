using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Repositories
{
	public class ServiceOfferingRepository : IServiceOfferingRepository
	{
		private readonly AppDbContext _context;


        public ServiceOfferingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(ServiceOffering serviceOffering)
		{
			_context.ServiceOfferings.Add(serviceOffering);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var serviceOfferingToDelete = await Get(id);
			if (serviceOfferingToDelete != null)
			{
				_context.ServiceOfferings.Remove(serviceOfferingToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<ServiceOffering> Get(int id)
		{
			return await _context.ServiceOfferings.FindAsync(id);
		}

		public async Task<List<ServiceOffering>> GetAll()
		{
			return await _context.ServiceOfferings.ToListAsync();
		}

		public async Task Update(int id, ServiceOffering serviceOffering)
		{
			var serviceOfferingToEdit = await Get(id);
			if (serviceOfferingToEdit != null)
			{
				serviceOfferingToEdit.Description = serviceOffering.Description;
				serviceOfferingToEdit.Status = serviceOffering.Status;
				await _context.SaveChangesAsync();
			}
		}
	}
}
