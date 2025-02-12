using App.Domain.Core.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IAddressRepository
	{
		Task Add(Address address);
		Task<Address> Get(int id);
		Task<List<Address>> GetAll();
		Task Delete(int id);
		Task Update(int id, Address address);
	}
}
