using GameCatalogue.Models;
using GameCatalogue.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalogue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DevelopersController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
            var developer = await _developerService.GetDeveloperByIdAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            return Ok(developer);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
        {
            var developer = await _developerService.GetAllDevelopersAsync();
            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult<Developer>> CreateGame(Developer developer)
        {
            await _developerService.CreateDeveloperAsync(developer);
            return CreatedAtAction(nameof(GetDeveloper), new { id = developer.DeveloperId }, developer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeveloper(int id, Developer developer)
        {
            if (id != developer.DeveloperId)
            {
                return BadRequest();
            }

            await _developerService.UpdateDeveloperAsync(developer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            await _developerService.DeleteDeveloperAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/games")]
        public async Task<ActionResult<Developer>> GetDeveloperWithGames(int id)
        {
            var developer = await _developerService.GetDeveloperWithGamesAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

    }
}
