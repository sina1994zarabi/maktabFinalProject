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

        public async Task Add(ServiceOffering serviceOffering,CancellationToken cancellationToken)
		{
			_context.ServiceOfferings.AddAsync(serviceOffering,cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Delete(int id,CancellationToken cancellationToken)
		{
			var serviceOfferingToDelete = await _context.ServiceOfferings.FindAsync(id,cancellationToken);
			if (serviceOfferingToDelete != null)
			{
				_context.ServiceOfferings.Remove(serviceOfferingToDelete);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task<ServiceOffering> Get(int id,CancellationToken cancellationToken)
		{
			return await _context.ServiceOfferings.FindAsync(id,cancellationToken);
		}

		public async Task<List<ServiceOffering>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.ServiceOfferings.ToListAsync(cancellationToken);
		}

		public async Task Update(ServiceOffering serviceOffering,CancellationToken cancellationToken)
		{
			var serviceOfferingToEdit = await _context.ServiceOfferings.FindAsync(serviceOffering.Id);
			if (serviceOfferingToEdit != null)
			{
				serviceOfferingToEdit.Description = serviceOffering.Description;
				serviceOfferingToEdit.Status = serviceOffering.Status;
				await _context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
