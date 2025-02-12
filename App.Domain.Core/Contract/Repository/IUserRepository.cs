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
		Task Add(UserBase user);
		Task<UserBase> Get(int id);
		Task<List<UserBase>> GetAll();
		Task Delete(int id);
		Task Update(UserBase user);
	}
}
