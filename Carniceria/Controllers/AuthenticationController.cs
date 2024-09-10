using Carniceria.Data.Models.Dto;
using Carniceria.Entities;
using Carniceria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Carniceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController:ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserServices _userService;

        public AuthenticationController(IConfiguration config, UserServices userService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            this._userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Autenticar(AuthenticationRequest authenticationRequestBody)
        {
            var user = _userService.ValidateUser(authenticationRequestBody);

            if (user is null)
                return Unauthorized();

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new[]
            {
        new Claim(ClaimTypes.Name, user.username)
    };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(24),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            // Devolver el token en un objeto JSON
            return Ok(new { token = tokenToReturn });
        }
    }
}
