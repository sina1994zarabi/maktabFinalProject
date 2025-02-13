using App.Domain.Core.DTOs.ServiceDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IServiceRepository
	{
		Task Add(CreateServiceDto service);
		Task<Service> Get(int id);
		Task<List<Service>> GetAll();
		Task Delete(int id);
		Task Update(UpdateServiceDto service);
	}
}
