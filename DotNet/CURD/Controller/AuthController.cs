using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CURD.DTO;
using CURD.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CURD.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<AppUser> userManager, IConfiguration congiguration)
        {
            _userManager = userManager;
            _configuration = congiguration;
        }
        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dot)
        {
            var user = await _userManager.FindByEmailAsync(email: dot.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, dot.Password))
            {
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:JwtSecret"]));
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                      new Claim("UserId",user.Id.ToString()),
                      new Claim("Email",user.Email.ToString())
                  }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescription);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token });
            }
            return Ok("UserName or password are wrong");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserDetail()
        {
            var usrId = User.Claims.First(x => x.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(usrId);
            return Ok(new { user });
        }

        [HttpPost("resetPassword")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromBody] ResetPasswordDto dto)
        {
            var userId = User.Claims.First(x => x.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var checkPass = await _userManager.CheckPasswordAsync(user, dto.OldPass);
            if (!checkPass)
            {
                return Ok(new { message = "Old password are wrong" });
            }
            var result = await _userManager.ChangePasswordAsync(user, dto.OldPass, dto.NewPass);
            if (result.Succeeded)
            {
                return Ok(new { message = "Password updated successfully" });
            }
            return Ok("Password are not change");
        }
    }
}