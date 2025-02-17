using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task Add(Review review, CancellationToken cancellation)
        {
            await _reviewRepository.Add(review, cancellation);
        }

        public async Task Delete(int id, CancellationToken cancellation)
        {
            await _reviewRepository.Delete(id, cancellation);
        }

        public async Task<Review> Get(int id, CancellationToken cancellation)
        {
            return await _reviewRepository.Get(id, cancellation);
        }

        public async Task<List<Review>> GetAll(CancellationToken cancellation)
        {
            return await _reviewRepository.GetAll(cancellation);
        }

        public async Task Update(Review review, CancellationToken cancellation)
        {
            await _reviewRepository.Update(review, cancellation);
        }
    }
}
