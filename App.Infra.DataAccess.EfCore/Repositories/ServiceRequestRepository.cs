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

        public async Task Add(ServiceRequest serviceRequest)
		{
			_context.ServiceRequests.Add(serviceRequest);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var serviceRequestToDelete = await Get(id);
			if (serviceRequestToDelete != null)
			{
				_context.ServiceRequests.Remove(serviceRequestToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<ServiceRequest> Get(int id)
		{
			return await _context.ServiceRequests.FindAsync(id);
		}

		public async Task<List<ServiceRequest>> GetAll()
		{
			return await _context.ServiceRequests.ToListAsync();
		}

		public async Task Update(int id, ServiceRequest serviceRequest)
		{
			var serviceRequestToEdit = await Get(id);
			if (serviceRequestToEdit != null)
			{
				serviceRequestToEdit.Title = serviceRequest.Title;
				serviceRequestToEdit.Status = serviceRequest.Status;
				serviceRequestToEdit.BookingDate = serviceRequest.BookingDate;
				serviceRequestToEdit.Description = serviceRequest.Description;
				serviceRequestToEdit.IsCompleted = serviceRequest.IsCompleted;
				await _context.SaveChangesAsync();
			}
		}
	}
}
