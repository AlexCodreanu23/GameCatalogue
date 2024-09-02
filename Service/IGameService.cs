using GameCatalogue.DTO;
using GameCatalogue.Models;

namespace GameCatalogue.Service
{
    public interface IGameService
    {
        Task<Game> GetGameByIdAsync(int id);
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task CreateGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(int id);

        Task<List<Game>> GetAffordableGamesAsync();
        Task<List<IGrouping<string, Game>>> GetGameCountsByGenreAsync();

    }

}