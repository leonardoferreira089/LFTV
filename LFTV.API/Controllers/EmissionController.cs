using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LFTV.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmissionController : ControllerBase
    {
        private readonly IEmissionService _service;

        public EmissionController(IEmissionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmissionDto>>> GetAll()
        {
            var emissions = await _service.GetAllAsync();
            return Ok(emissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmissionDto>> GetById(int id)
        {
            var emission = await _service.GetByIdAsync(id);
            if (emission == null)
                return NotFound();
            return Ok(emission);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<EmissionDto>>> GetByDate(DateTime date)
        {
            var emissions = await _service.GetByDateAsync(date);
            return Ok(emissions);
        }

        [HttpPost]
        public async Task<ActionResult<EmissionDto>> Create(CreateEmissionDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmissionDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}