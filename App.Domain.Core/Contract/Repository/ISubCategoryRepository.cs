using App.Domain.Core.DTOs.SubCategoryDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface ISubCategoryRepository
	{
		Task Add(CreateSubCategoryDto subcategory);
		Task<SubCategory> Get(int id);
		Task<List<SubCategory>> GetAll();
		Task Delete(int id);
		Task Update(UpdateSubCategoryDto subcategory);
	}
}
