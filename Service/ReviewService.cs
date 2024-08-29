using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<Review> GetReviewByIdAsync(int id)
        {
            return _reviewRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return _reviewRepository.GetAllAsync();
        }

        public Task CreateReviewAsync(Review review)
        {
            return _reviewRepository.AddAsync(review);
        }

        public Task UpdateReviewAsync(Review review)
        {
            return _reviewRepository.UpdateAsync(review);
        }

        public Task DeleteReviewAsync(int id)
        {
            return _reviewRepository.DeleteAsync(id);
        }
    }
}
