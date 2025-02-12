using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IServiceRequestRepository
	{
		Task Add(ServiceRequest serviceRequest);
		Task<ServiceRequest> Get(int id);
		Task<List<ServiceRequest>> GetAll();
		Task Delete(int id);
		Task Update(int id,ServiceRequest serviceRequest);
	}
}
