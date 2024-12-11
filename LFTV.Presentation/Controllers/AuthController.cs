using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFTV.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] dynamic user)
        {
            return Ok(new { message = "Compte créé avec succès." });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] dynamic credentials)
        {
            return Ok(new { token = "fake-jwt-token" });
        }
    }
}
