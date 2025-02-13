using App.Domain.Core.DTOs.CategoryDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface ICategoryRepository
	{
		Task Add(CreateCategoryDto category);
		Task<Category> Get(int id);
		Task<List<Category>> GetAll();
		Task Delete(int id);
		Task Update(UpdateCategoryDto category);
	}
}
