using GameCatalogue.DTO;
using GameCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogue.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task AddAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Game>> GetAffordableGamesAsync()
        {
            return await _context.Games
                .Where(g => g.Price < 50)
                .ToListAsync();
        }

        public async Task<List<IGrouping<string, Game>>> GetGameCountsByGenreAsync()
        {
            return await _context.Games
                .GroupBy(game => game.Genre)
                .ToListAsync();
        }

    }
}