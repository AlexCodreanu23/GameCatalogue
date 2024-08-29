using GameCatalogue.Models;
using System.Threading.Tasks;

namespace GameCatalogue.Repositories
{
    public interface IUnitOfWork
    {
        IGameRepository Games { get; }
        IDeveloperRepository Developers { get; }
        IReviewRepository Reviews { get; }
        ISystemRequirementRepository SystemRequirements { get; }
        IUserRepository Users { get; }

        Task CompleteAsync();
    }
}
