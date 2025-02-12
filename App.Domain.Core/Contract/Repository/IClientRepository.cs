using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IClientRepository
	{
		Task Add(Client client);
		Task<Client> Get(int id);
		Task<List<Client>> GetAll();
		Task Delete(int id);
		Task Update(int id, Client client);
	}
}
