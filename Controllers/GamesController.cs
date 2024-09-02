using GameCatalogue.Models;
using GameCatalogue.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalogue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            await _gameService.CreateGameAsync(game);
            return CreatedAtAction(nameof(GetGame), new { id = game.GameId }, game);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateGame(int id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

            await _gameService.UpdateGameAsync(game);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }

        [HttpGet("affordable")]
        public async Task<ActionResult<List<Game>>> GetAffordableGames()
        {
            var affordableGames = await _gameService.GetAffordableGamesAsync();
            return Ok(affordableGames);
        }
        [HttpGet("games-by-genre")]
        public async Task<ActionResult<List<IGrouping<string, Game>>>> GetGameCountsByGenre()
        {
            var genreGameCounts = await _gameService.GetGameCountsByGenreAsync();
            return Ok(genreGameCounts);
        }
    }
}