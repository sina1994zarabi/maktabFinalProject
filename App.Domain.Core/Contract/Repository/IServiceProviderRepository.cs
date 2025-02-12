using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IServiceProviderRepository
	{
		Task Add(ServiceProvider serviceProvider);
		Task<ServiceProvider> Get(int id);
		Task<List<ServiceProvider>> GetAll();
		Task Delete(int id);
		Task Update(int id, ServiceProvider serviceProvider);
	}
}
