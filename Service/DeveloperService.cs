using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return _developerRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            return _developerRepository.GetAllAsync();
        }

        public Task CreateDeveloperAsync(Developer developer)
        {
            return _developerRepository.AddAsync(developer);
        }

        public Task UpdateDeveloperAsync(Developer developer)
        {
            return _developerRepository.UpdateAsync(developer);
        }

        public Task DeleteDeveloperAsync(int id)
        {
            return _developerRepository.DeleteAsync(id);
        }
    }
}
