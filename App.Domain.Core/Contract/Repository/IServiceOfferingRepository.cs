using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IServiceOfferingRepository
	{
		Task Add(ServiceOffering serviceOffering);
		Task<ServiceOffering> Get(int id);
		Task<List<ServiceOffering>> GetAll();
		Task Delete(int id);
		Task Update(int id,ServiceOffering serviceOffering);
	}
}
