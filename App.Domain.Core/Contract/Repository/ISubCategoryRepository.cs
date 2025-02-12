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
		Task Add(Subcategory subcategory);
		Task<Subcategory> Get(int id);
		Task<List<Subcategory>> GetAll();
		Task Delete(int id);
		Task Update(int id,Subcategory subcategory);
	}
}
