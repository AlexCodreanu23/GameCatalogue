using GameCatalogue.Models;
using GameCatalogue.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalogue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemRequirementsController : ControllerBase
    {
        private readonly ISystemRequirementService _systemRequirementService;

        public SystemRequirementsController(ISystemRequirementService systemRequirementService)
        {
            _systemRequirementService = systemRequirementService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SystemRequirement>> GetSystemRequirement(int id)
        {
            var systemRequirement = await _systemRequirementService.GetSystemRequirementByIdAsync(id);
            if (systemRequirement == null)
            {
                return NotFound();
            }
            return Ok(systemRequirement);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemRequirement>>> GetSystemRequirements()
        {
            var systemRequirements = await _systemRequirementService.GetAllSystemRequirementsAsync();
            return Ok(systemRequirements);
        }

        [HttpPost]
        public async Task<ActionResult<SystemRequirement>> CreateSystemRequirement(SystemRequirement systemRequirement)
        {
            await _systemRequirementService.CreateSystemRequirementAsync(systemRequirement);
            return CreatedAtAction(nameof(GetSystemRequirement), new { id = systemRequirement.RequirementsId }, systemRequirement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSystemRequirement(int id, SystemRequirement systemRequirement)
        {
            if (id != systemRequirement.RequirementsId)
            {
                return BadRequest();
            }

            await _systemRequirementService.UpdateSystemRequirementAsync(systemRequirement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemRequirement(int id)
        {
            await _systemRequirementService.DeleteSystemRequirementAsync(id);
            return NoContent();
        }
    }
}
