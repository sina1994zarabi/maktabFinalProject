using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
			_context = context;
        }


        public async Task Add(Review review)
		{
			_context.Reviews.Add(review);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var reviewToDelete = await Get(id);
			if (reviewToDelete != null)
			{
				_context.Reviews.Remove(reviewToDelete);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Review> Get(int id)
		{
			return await _context.Reviews.FindAsync(id);
		}

		public async Task<List<Review>> GetAll()
		{
			return await _context.Reviews.ToListAsync();
		}

		public async Task Update(int id,Review review)
		{
			var reviewToUpdate = await Get(id);
			if (reviewToUpdate != null)
			{
				reviewToUpdate.Comment = review.Comment;
				reviewToUpdate.Rating = review.Rating;
				await _context.SaveChangesAsync();
			}
		}
	}
}
