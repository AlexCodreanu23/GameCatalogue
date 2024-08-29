using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return _unitOfWork.Developers.GetByIdAsync(id);
        }

        public Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            return _unitOfWork.Developers.GetAllAsync();
        }

        public async Task CreateDeveloperAsync(Developer developer)
        {
            await _unitOfWork.Developers.AddAsync(developer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateDeveloperAsync(Developer developer)
        {
            await _unitOfWork.Developers.UpdateAsync(developer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteDeveloperAsync(int id)
        {
            await _unitOfWork.Developers.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
