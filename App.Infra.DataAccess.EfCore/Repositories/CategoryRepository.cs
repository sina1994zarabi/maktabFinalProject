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
	public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext _context;


        public CategoryRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(Category category)
		{
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var CategoryToDelete = await Get(id);
			if (CategoryToDelete != null)
			{
				_context.Categories.Remove(CategoryToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Category> Get(int id)
		{
			return await _context.Categories.FindAsync(id);
		}

		public async Task<List<Category>> GetAll()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task Update(int id, Category category)
		{
			var categoryToUpdate = await Get(id);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Title = category.Title;
				await _context.SaveChangesAsync();
			}
		}
	}
}
