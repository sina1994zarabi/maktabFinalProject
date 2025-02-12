using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Repositories
{
	public class CityRepository : ICityRepository
	{
		private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
			_context = context;
        }

        public async Task Add(City city)
		{
			_context.Cities.Add(city);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var cityToDelete = await Get(id);
			if (cityToDelete != null)
			{
				_context.Cities.Remove(cityToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<City> Get(int id)
		{
			return await _context.Cities.FindAsync(id);
		}

		public async Task<List<City>> GetAll()
		{
			return await _context.Cities.ToListAsync();
		}

		public async Task Update(int id, City city)
		{
			var cityToEdit = await Get(id);
			if ( cityToEdit != null )
			{
				cityToEdit.Name = city.Name;
				await _context.SaveChangesAsync();
			}
		}
	}
}
