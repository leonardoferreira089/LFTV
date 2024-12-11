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
    public class HistoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHistory()
        {
            var viewedPrograms = ProgramController.programs
                .Where(p => p.Status == "Déjà visionné");

            return Ok(viewedPrograms);
        }
    }
}
