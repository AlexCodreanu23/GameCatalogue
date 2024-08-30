using GameCatalogue.DTO;
using GameCatalogue.Models;
namespace GameCatalogue.Repositories;

public interface IGameRepository
{
    Task<Game> GetByIdAsync(int id);
    Task<IEnumerable<Game>> GetAllAsync();
    Task AddAsync(Game game);
    Task UpdateAsync(Game game);
    Task DeleteAsync(int id);

    Task<List<Game>> GetAffordableGamesAsync();
    Task<List<IGrouping<string, Game>>> GetGameCountsByGenreAsync();

}
