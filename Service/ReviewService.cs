using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Review> GetReviewByIdAsync(int id)
        {
            return _unitOfWork.Reviews.GetByIdAsync(id);
        }

        public Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return _unitOfWork.Reviews.GetAllAsync();
        }

        public async Task CreateReviewAsync(Review review)
        {
            await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {
            await _unitOfWork.Reviews.UpdateAsync(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _unitOfWork.Reviews.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
