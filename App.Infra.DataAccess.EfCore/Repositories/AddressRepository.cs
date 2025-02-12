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
	public class AddressRepository : IAddressRepository
	{
		private readonly AppDbContext _context;


        public AddressRepository(AppDbContext context)
        {
			_context = context;
        }


        public async Task Add(Address address)
		{
			_context.Addresses.Add(address);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var addressToRemove = await Get(id);
			if (addressToRemove != null)
			{
				_context.Addresses.Remove(addressToRemove);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Address> Get(int id)
		{
			return await _context.Addresses.FindAsync(id);
		}

		public async Task<List<Address>> GetAll()
		{
			return await _context.Addresses.ToListAsync();
		}

		public async Task Update(int id, Address address)
		{
			var addressToEdit = await Get(id);
			if (addressToEdit != null)
			{
				addressToEdit.Description = address.Description;
				addressToEdit.PostalCode = address.PostalCode;
				await _context.SaveChangesAsync();
			}
		}
	}
}
