using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
	public interface IReviewRepository
	{
		Task Add(Review review);
		Task<Review> Get(int id);
		Task<List<Review>> GetAll();
		Task Delete(int id);
		Task Update(int id,Review review);
	}
}
