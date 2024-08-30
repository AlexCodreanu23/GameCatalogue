using GameCatalogue.DTO;
using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _unitOfWork.Games.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _unitOfWork.Games.GetAllAsync();
        }

        public async Task CreateGameAsync(Game game)
        {
            await _unitOfWork.Games.AddAsync(game);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            await _unitOfWork.Games.UpdateAsync(game);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            await _unitOfWork.Games.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<Game>> GetAffordableGamesAsync() 
        {
            return await _unitOfWork.Games.GetAffordableGamesAsync();
        }

        public async Task<List<IGrouping<string, Game>>> GetGameCountsByGenreAsync()
        {
            return await _unitOfWork.Games.GetGameCountsByGenreAsync();
        }

    }
}