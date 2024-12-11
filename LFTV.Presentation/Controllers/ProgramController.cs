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
    public class ProgramController : ControllerBase
    {
        public static List<dynamic> programs = new List<dynamic>();

        [HttpPost]
        public IActionResult CreateProgram([FromBody] dynamic program)
        {
            programs.Add(program);
            return Created("", program);
        }

        [HttpGet]
        public IActionResult GetPrograms()
        {
            return Ok(programs);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProgram(int id, [FromBody] dynamic updatedProgram)
        {
            if (id < 0 || id >= programs.Count)
                return NotFound();

            programs[id] = updatedProgram;
            return NoContent();
        }
    }
}
