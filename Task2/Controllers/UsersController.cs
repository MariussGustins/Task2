using Task2.Interface;
using Task2.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto userDto)
        {
            var userId = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUsers), new { id = userId }, null);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.GetUserByUsernameAndPasswordAsync(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Unauthorized(new { login = false });
            }

            return Ok(new { login = true });
        }
    }
}