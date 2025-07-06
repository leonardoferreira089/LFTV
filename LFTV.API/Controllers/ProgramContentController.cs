using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LFTV.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramContentController : ControllerBase
    {
        private readonly IProgramContentService _service;

        public ProgramContentController(IProgramContentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramContentDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramContentDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpGet("emission/{emissionId}")]
        public async Task<ActionResult<IEnumerable<ProgramContentDto>>> GetByEmissionId(int emissionId)
        {
            var items = await _service.GetByEmissionIdAsync(emissionId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<ProgramContentDto>> Create(CreateProgramContentDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProgramContentDto dto)
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