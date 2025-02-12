using App.Domain.Core.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface ICityRepository
	{
		Task Add(City city);
		Task<City> Get(int id);
		Task<List<City>> GetAll();
		Task Delete(int id);
		Task Update(int id,City city);
	}
}
