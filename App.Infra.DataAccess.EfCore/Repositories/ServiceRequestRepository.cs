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
	public class ServiceRequestRepository : IServiceRequestRepository
	{
		private readonly AppDbContext _context;

        public ServiceRequestRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(ServiceRequest serviceRequest,CancellationToken cancellationToken)
		{
			await _context.ServiceRequests.AddAsync(serviceRequest,cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Delete(int id,CancellationToken cancellationToken)
		{
			var serviceRequestToDelete = await _context.ServiceRequests.FindAsync(id,cancellationToken);
			if (serviceRequestToDelete != null)
			{
				_context.ServiceRequests.Remove(serviceRequestToDelete);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task<ServiceRequest> Get(int id,CancellationToken cancellationToken)
		{
			return await _context.ServiceRequests.FindAsync(id,cancellationToken);
		}

		public async Task<List<ServiceRequest>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.ServiceRequests.ToListAsync(cancellationToken);
		}

		public async Task Update(ServiceRequest serviceRequest,CancellationToken cancellationToken)
		{
			var serviceRequestToEdit = await _context.ServiceRequests.FindAsync(serviceRequest.Id,cancellationToken);
			if (serviceRequestToEdit != null)
			{
				serviceRequestToEdit.Title = serviceRequest.Title;
				serviceRequestToEdit.Status = serviceRequest.Status;
				serviceRequestToEdit.BookingDate = serviceRequest.BookingDate;
				serviceRequestToEdit.Description = serviceRequest.Description;
				serviceRequestToEdit.IsCompleted = serviceRequest.IsCompleted;
				await _context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
