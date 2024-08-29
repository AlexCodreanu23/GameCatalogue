using GameCatalogue.Models;

namespace GameCatalogue.Repositories
{
    public interface ISystemRequirementRepository
    {
        Task<SystemRequirement> GetByIdAsync(int id);
        Task<IEnumerable<SystemRequirement>> GetAllAsync();
        Task AddAsync(SystemRequirement systemRequirement);
        Task UpdateAsync(SystemRequirement systemRequirement);
        Task DeleteAsync(int id);
    }
}
