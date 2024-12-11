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
    public class HomeController : ControllerBase
    {
        [HttpGet("current")]
        public IActionResult GetCurrentProgram()
        {
            // Simulation de données pour l'instant
            var program = new
            {
                Image = "https://example.com/image.jpg",
                Description = "Description de l'émission en cours.",
                Link = "https://example.com/program"
            };

            return Ok(program);
        }
    }
}
