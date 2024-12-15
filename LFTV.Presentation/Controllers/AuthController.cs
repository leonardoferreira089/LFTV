using LFTV.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFTV.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LftvAuthenticationService _authenticationService;

        public AuthController(LftvAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            // Simuler une authentification
            // Cela pourrait être remplacé par une vérification réelle des utilisateurs dans une base de données
            if (loginRequest.Username == "admin" && loginRequest.Password == "password")
            {
                var token = await _authenticationService.GenerateJwtToken(loginRequest.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
