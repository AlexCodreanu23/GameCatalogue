using GameCatalogue.Models;

namespace GameCatalogue.Repositories
{
    public interface IDeveloperRepository
    {
        Task<Developer> GetByIdAsync(int id);
        Task<IEnumerable<Developer>> GetAllAsync();
        Task AddAsync(Developer developer);
        Task UpdateAsync(Developer developer);
        Task DeleteAsync(int id);
    }
}
