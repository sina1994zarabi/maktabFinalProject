using App.Domain.Core.Contract.Repository;
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

        public async Task Add(CreateExpertDto expert)
		{
			var newExpert = new Expert
			{
				FullName = expert.FullName,
				Username = expert.Username,
				Email = expert.Email,
				PhoneNumber = expert.PhoneNumber,
				ProfilePicture = expert.ImagePath,
				Gender = expert.Gender,
				Role = UserRole.Expert,
				
			};

			await _context.Experts.AddAsync(newExpert);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var serviceProviderToDelete = await Get(id);
			if (serviceProviderToDelete != null)
			{
				_context.Experts.Remove(serviceProviderToDelete);
				await _context.SaveChangesAsync();
			}

		}

		public async Task<Expert> Get(int id)
		{
			return await _context.Experts.FindAsync(id);
		}

		public async Task<List<Expert>> GetAll()
		{
			return await _context.Experts.ToListAsync();
		}

		public async Task Update(UpdateExpertDto expert)
		{
			var expertToEdit = await Get(expert.Id);
			if (expertToEdit != null)
			{
				expertToEdit.Username = expert.Username;
				expertToEdit.Email = expert.Email;
				expertToEdit.ProfilePicture = expert.ImagePath;
				expertToEdit.PhoneNumber = expert.PhoneNumber;
				expertToEdit.FullName = expert.FullName;
				await _context.SaveChangesAsync();
			}
		}
	}
}
