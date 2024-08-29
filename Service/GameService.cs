using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<Game> GetGameByIdAsync(int id)
        {
            return _gameRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return _gameRepository.GetAllAsync();
        }

        public Task CreateGameAsync(Game game)
        {
            return _gameRepository.AddAsync(game);
        }

        public Task UpdateGameAsync(Game game)
        {
            return _gameRepository.UpdateAsync(game);
        }

        public Task DeleteGameAsync(int id)
        {
            return _gameRepository.DeleteAsync(id);
        }
    }

}
