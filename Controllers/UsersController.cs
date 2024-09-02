using GameCatalogue.Models;
using GameCatalogue.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace GameCatalogue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly EmailService _emailService;
        private readonly IUserService _userService;

        public UsersController(EmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var subject = "User Data Accessed";
            var plainTextContent = "The user data has been accessed.";
            var htmlContent = "<strong>The user data has been accessed.</strong>";
            await _emailService.SendEmailAsync("silviu.codreanu@gmail.com", subject, plainTextContent, htmlContent);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}