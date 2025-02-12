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
	public class SubCategoryRepository : ISubCategoryRepository
	{
		private readonly AppDbContext _context;

        public SubCategoryRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(Subcategory subcategory)
		{
			_context.Subcategories.Add(subcategory);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var subCategoryToDelete = await Get(id);
			if (subCategoryToDelete != null)
			{
				_context.Subcategories.Remove(subCategoryToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Subcategory> Get(int id)
		{
			return await _context.Subcategories.FindAsync(id);
		}

		public async Task<List<Subcategory>> GetAll()
		{
			return await _context.Subcategories.ToListAsync();
		}

		public async Task Update(int id, Subcategory subcategory)
		{
			var subcategoryToUpdate = await Get(id);
			if (subcategoryToUpdate != null)
			{
				subcategoryToUpdate.Title = subcategory.Title;
				subcategoryToUpdate.CategoryId = subcategory.CategoryId;
				await _context.SaveChangesAsync();
			}
		}
	}
}
