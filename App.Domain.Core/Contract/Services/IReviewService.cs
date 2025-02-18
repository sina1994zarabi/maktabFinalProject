using App.Domain.Core.DTOs.ReviewDto;
using App.Domain.Core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IReviewService
    {
        Task Add(CreateReviewDto review, CancellationToken cancellation);
        Task<Review> Get(int id, CancellationToken cancellation);
        Task<List<Review>> GetAll(CancellationToken cancellation);
        Task Delete(int id, CancellationToken cancellation);
        Task Update(Review review, CancellationToken cancellation);
    }
}
