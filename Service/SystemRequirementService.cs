using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class SystemRequirementService : ISystemRequirementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemRequirementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SystemRequirement> GetSystemRequirementByIdAsync(int id)
        {
            return _unitOfWork.SystemRequirements.GetByIdAsync(id);
        }

        public Task<IEnumerable<SystemRequirement>> GetAllSystemRequirementsAsync()
        {
            return _unitOfWork.SystemRequirements.GetAllAsync();
        }

        public async Task CreateSystemRequirementAsync(SystemRequirement systemRequirement)
        {
            await _unitOfWork.SystemRequirements.AddAsync(systemRequirement);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateSystemRequirementAsync(SystemRequirement systemRequirement)
        {
            await _unitOfWork.SystemRequirements.UpdateAsync(systemRequirement);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteSystemRequirementAsync(int id)
        {
            await _unitOfWork.SystemRequirements.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
