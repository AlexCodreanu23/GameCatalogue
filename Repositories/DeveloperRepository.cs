using GameCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogue.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Developer> GetByIdAsync(int id)
        {
            return await _context.Developers.FindAsync(id);
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _context.Developers.ToListAsync();
        }

        public async Task AddAsync(Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developer developer)
        {
            _context.Developers.Update(developer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Developer> GetDeveloperWithGamesAsync(int developerId)
        {
            return await _context.Developers
                .Include(d => d.GameDevelopers)
                    .ThenInclude(gd => gd.Game)
                .FirstOrDefaultAsync(d => d.DeveloperId == developerId);
        }
    }
}
