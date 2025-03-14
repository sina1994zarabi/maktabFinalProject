﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.DTOs.ServiceOfferingDto;
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

        public async Task Add(CreateServiceOfferingDto serviceOffering,CancellationToken cancellationToken)
		{
			var newServiceOfferin = new ServiceOffering
			{
				Description = serviceOffering.Description,
				Status = serviceOffering.Status,
				ExpertId = serviceOffering.ExpertId,
				ServiceRequestId = serviceOffering.ServiceRequestId
			};
			_context.ServiceOfferings.AddAsync(newServiceOfferin,cancellationToken);
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
			return await _context.ServiceOfferings.
						FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
		}

		public async Task<List<ServiceOffering>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.ServiceOfferings
							     .Include(so => so.Expert)
									.ThenInclude(e => e.AppUser)
								 .Include(so => so.ServiceRequest)
									.ThenInclude(sr => sr.Client)
								 .ToListAsync(cancellationToken);
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
