using CURD.DTO;
using CURD.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CURD.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserRegisterDto dto)
        {
            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.FirstName + "123"
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            return Ok(new { result });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dot)
        {
            var user = await _userManager.FindByEmailAsync(email: dot.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, dot.Password))
            {
                return Ok(new { user });
            }
            return Ok("UserName or password are wrong");
        }
    }
}