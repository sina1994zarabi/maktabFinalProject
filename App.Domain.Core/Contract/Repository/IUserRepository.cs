using App.Domain.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IUserRepository
	{
		Task Add(AppUser user);
		Task<AppUser> Get(int id);
		Task<List<AppUser>> GetAll();
		Task Delete(int id);
		Task Update(AppUser user);
	}
}
