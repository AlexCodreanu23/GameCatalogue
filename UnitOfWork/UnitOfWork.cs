using GameCatalogue.Models;
using GameCatalogue.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GameCatalogue.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Games = new GameRepository(_context);
            Developers = new DeveloperRepository(_context);
            Reviews = new ReviewRepository(_context);
            SystemRequirements = new SystemRequirementRepository(_context);
            Users = new UserRepository(_context);
        }

        public IGameRepository Games { get; private set; }
        public IDeveloperRepository Developers { get; private set; }
        public IReviewRepository Reviews { get; private set; }
        public ISystemRequirementRepository SystemRequirements { get; private set; }
        public IUserRepository Users { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
