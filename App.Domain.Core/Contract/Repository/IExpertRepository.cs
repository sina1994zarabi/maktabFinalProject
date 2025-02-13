using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IExpertRepository
	{
		Task Add(CreateExpertDto expert);
		Task<Expert> Get(int id);
		Task<List<Expert>> GetAll();
		Task Delete(int id);
		Task Update(UpdateExpertDto expert);
	}
}
