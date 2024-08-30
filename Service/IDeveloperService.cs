using GameCatalogue.Models;

namespace GameCatalogue.Service
{
    public interface IDeveloperService
    {
        Task<Developer> GetDeveloperByIdAsync(int id);
        Task<IEnumerable<Developer>> GetAllDevelopersAsync();
        Task CreateDeveloperAsync(Developer developer);
        Task UpdateDeveloperAsync(Developer developer);
        Task DeleteDeveloperAsync(int id);

        Task<Developer> GetDeveloperWithGamesAsync(int developerId);
    }
}
