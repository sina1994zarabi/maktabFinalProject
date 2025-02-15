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


        public async Task Add(Review review,CancellationToken cancellation)
		{
			_context.Reviews.Add(review);
			await _context.SaveChangesAsync(cancellation);
		}

		public async Task Delete(int id,CancellationToken cancellation)
		{
			var reviewToDelete = await _context.Reviews.FindAsync(id,cancellation);
			if (reviewToDelete != null)
			{
				_context.Reviews.Remove(reviewToDelete);
				await _context.SaveChangesAsync(cancellation);
			}
		}

		public async Task<Review> Get(int id,CancellationToken cancellation)
		{
			return await _context.Reviews.FindAsync(id,cancellation);
		}

		public async Task<List<Review>> GetAll(CancellationToken cancellation)
		{
			return await _context.Reviews.ToListAsync(cancellation);
		}

		public async Task Update(Review review,CancellationToken cancellation)
		{
			var reviewToUpdate = await _context.Reviews.FindAsync(review.Id);
			if (reviewToUpdate != null)
			{
				reviewToUpdate.Comment = review.Comment;
				reviewToUpdate.Rating = review.Rating;
				await _context.SaveChangesAsync();
			}
		}
	}
}
