using GameCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogue.Repositories
{
    public class SystemRequirementRepository : ISystemRequirementRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemRequirementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SystemRequirement> GetByIdAsync(int id)
        {
            return await _context.SystemRequirements.FindAsync(id);
        }

        public async Task<IEnumerable<SystemRequirement>> GetAllAsync()
        {
            return await _context.SystemRequirements.ToListAsync();
        }

        public async Task AddAsync(SystemRequirement systemRequirement)
        {
            _context.SystemRequirements.Add(systemRequirement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemRequirement systemRequirement)
        {
            _context.SystemRequirements.Update(systemRequirement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var systemRequirement = await _context.SystemRequirements.FindAsync(id);
            if (systemRequirement != null)
            {
                _context.SystemRequirements.Remove(systemRequirement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
