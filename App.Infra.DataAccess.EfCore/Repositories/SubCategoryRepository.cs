using App.Domain.Core.Contract.Repository;
using App.Domain.Core.DTOs.SubCategoryDto;
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

        public async Task Add(CreateSubCategoryDto subcategory)
		{
			var newSubCategory = new SubCategory
			{
				Title = subcategory.Title,
				CategoryId = subcategory.CategoryId,
			};
			await _context.Subcategories.AddAsync(newSubCategory);
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

		public async Task<SubCategory> Get(int id)
		{
			return await _context.Subcategories.FindAsync(id);
		}

		public async Task<List<SubCategory>> GetAll()
		{
			return await _context.Subcategories.ToListAsync();
		}

		public async Task Update(UpdateSubCategoryDto subcategory)
		{
			var subcategoryToUpdate = await Get(subcategory.Id);
			if (subcategoryToUpdate != null)
			{
				subcategoryToUpdate.Title = subcategory.Title;
				subcategoryToUpdate.CategoryId = subcategory.CategoryId;
				await _context.SaveChangesAsync();
			}
		}
	}
}
