using GameCatalogue.Models;

namespace GameCatalogue.Service
{
    public interface ISystemRequirementService
    {
        Task<SystemRequirement> GetSystemRequirementByIdAsync(int id);
        Task<IEnumerable<SystemRequirement>> GetAllSystemRequirementsAsync();
        Task CreateSystemRequirementAsync(SystemRequirement systemRequirement);
        Task UpdateSystemRequirementAsync(SystemRequirement systemRequirement);
        Task DeleteSystemRequirementAsync(int id);
    }

}
