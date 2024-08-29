using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class SystemRequirementService : ISystemRequirementService
    {
        private readonly ISystemRequirementRepository _systemRequirementRepository;

        public SystemRequirementService(ISystemRequirementRepository systemRequirementRepository)
        {
            _systemRequirementRepository = systemRequirementRepository;
        }

        public Task<SystemRequirement> GetSystemRequirementByIdAsync(int id)
        {
            return _systemRequirementRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<SystemRequirement>> GetAllSystemRequirementsAsync()
        {
            return _systemRequirementRepository.GetAllAsync();
        }

        public Task CreateSystemRequirementAsync(SystemRequirement systemRequirement)
        {
            return _systemRequirementRepository.AddAsync(systemRequirement);
        }

        public Task UpdateSystemRequirementAsync(SystemRequirement systemRequirement)
        {
            return _systemRequirementRepository.UpdateAsync(systemRequirement);
        }

        public Task DeleteSystemRequirementAsync(int id)
        {
            return _systemRequirementRepository.DeleteAsync(id);
        }
    }
}
