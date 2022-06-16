using cw8.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace cw8.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(UserDTO userDTO)
        {
            

            var claims = new Claim[]
            {
            new Claim(ClaimTypes.Role, "user"),
            new Claim(ClaimTypes.Role, "admin")
            };

            var secret = "fdsfgsdguhindfrsghurdfenhgjirdf,.fehauijkjoiprewoipujwhtrjklgnjmkvbcxnjklzxcvjimopksadefopk[ewqrl;,[asijodfguijhoqwrfikojpvjhuiadshgiujdrfk";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var options = new JwtSecurityToken("https://localhost", "https://localhost",
                claims, expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: creds);

            var refreshToken = "";
            using (var genNum = RandomNumberGenerator.Create())
            {
                var r = new byte[1024];
                genNum.GetBytes(r);
                refreshToken = Convert.ToBase64String(r);
            }

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(options),
                refreshToken
            });
        }

        [HttpPost]
        public IActionResult CreateUser(UserDTO userDTO)
        {
            
            var hasher = new PasswordHasher<UserDTO>();
            var hashedPassword = hasher.HashPassword(userDTO, userDTO.Password);

            return Ok(hashedPassword);
        }

        [HttpPost("api/refresh")]
        public IActionResult RefreshToken()
        {
            return Ok();
        }
    }
}
