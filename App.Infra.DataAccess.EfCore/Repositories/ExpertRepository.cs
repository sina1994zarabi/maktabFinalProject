﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Repositories
{
	public class ExpertRepository : IExpertRepository
	{
		private readonly AppDbContext _context;

        public ExpertRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(CreateExpertDto expert,CancellationToken cancellation)
		{
			var newExpert = new Expert
			{
				FullName = expert.FullName,
				//UserName = expert.Username,
				//Email = expert.Email,
				PhoneNumber = expert.PhoneNumber,
				//ProfilePicture = expert.ImagePath,
				Gender = expert.Gender
			};

			await _context.Experts.AddAsync(newExpert,cancellation);
			await _context.SaveChangesAsync(cancellation);
		}

		public async Task Delete(int id,CancellationToken cancellation)
		{
			var serviceProviderToDelete = await _context.Experts.FindAsync(id,cancellation);
			if (serviceProviderToDelete != null)
			{
				_context.Experts.Remove(serviceProviderToDelete);
				await _context.SaveChangesAsync(cancellation);
			}

		}

		public async Task<Expert> Get(int id,CancellationToken cancellation)
		{
			return await _context.Experts.FindAsync(id, cancellation);
		}

		public async Task<List<Expert>> GetAll(CancellationToken cancellation)
		{
			return await _context.Experts.ToListAsync(cancellation);
		}

		public async Task Update(UpdateExpertDto expert,CancellationToken cancellation)
		{
			var expertToEdit = await _context.Experts.FindAsync(expert.Id, cancellation);
			if (expertToEdit != null)
			{
				//expertToEdit.UserName = expert.Username;
				//expertToEdit.Email = expert.Email;
				//expertToEdit.ProfilePicture = expert.ImagePath;
				expertToEdit.PhoneNumber = expert.PhoneNumber;
				expertToEdit.FullName = expert.FullName;
				await _context.SaveChangesAsync(cancellation);
			}
		}
	}
}
