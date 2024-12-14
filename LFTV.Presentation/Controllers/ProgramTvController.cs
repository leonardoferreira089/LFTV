using LFTV.Domain.Entities;
using LFTV.Infrastructure.Repositories;
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
    public class ProgramTVController : ControllerBase
    {
        private readonly IProgramtvRepository _programtvRepository;

        public ProgramTVController(IProgramtvRepository programtvRepository)
        {
            _programtvRepository = programtvRepository;
        }

        // GET: api/program
        [HttpGet]
        public async Task<IActionResult> GetAllPrograms()
        {
            var tvprograms = await _programtvRepository.GetAllProgramsAsync();
            return Ok(tvprograms);
        }

        // GET: api/program/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramById(int id)
        {
            var program = await _programtvRepository.GetProgramByIdAsync(id);

            if (program == null)
                return NotFound($"Program with ID {id} not found.");

            return Ok(program);
        }

        // POST: api/program
        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] ProgramTv programtv)
        {
            if (programtv == null)
                return BadRequest("Invalid program data.");

            await _programtvRepository.AddProgramAsync(programtv);
            return CreatedAtAction(nameof(GetProgramById), new { id = programtv.Id }, programtv);
        }

        // PUT: api/program/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(int id, [FromBody] ProgramTv programtv)
        {
            if (id != programtv.Id)
                return BadRequest("ID mismatch.");

            var existingProgram = await _programtvRepository.GetProgramByIdAsync(id);
            if (existingProgram == null)
                return NotFound($"Program with ID {id} not found.");

            await _programtvRepository.UpdateProgramAsync(programtv);
            return NoContent();
        }

        // DELETE: api/program/{id}
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProgram(int id)
            {
                var tvprogram = await _programtvRepository.GetProgramByIdAsync(id);
                if (tvprogram == null)
                    return NotFound($"Program with ID {id} not found.");

                await _programtvRepository.DeleteProgramAsync(id);  
                return NoContent();
            }
        }
}
