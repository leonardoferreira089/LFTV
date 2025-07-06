using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LFTV.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IEmissionService _emissionService;
        private readonly IProgramContentService _contentService;

        public HomeController(
            IEmissionService emissionService,
            IProgramContentService contentService)
        {
            _emissionService = emissionService;
            _contentService = contentService;
        }

        // GET: api/home/today
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<EmissionDto>>> GetTodayPrograms()
        {
            var today = DateTime.UtcNow.Date;
            var emissions = await _emissionService.GetByDateAsync(today);
            return Ok(emissions);
        }

        // GET: api/home/now
        [HttpGet("now")]
        public async Task<ActionResult<IEnumerable<EmissionDto>>> GetNowPlaying()
        {
            var now = DateTime.UtcNow;
            var today = now.Date;
            var emissions = await _emissionService.GetByDateAsync(today);
            var current = emissions.Where(e =>
                e.StartTime <= now.TimeOfDay && e.EndTime > now.TimeOfDay
            ).ToList();
            return Ok(current);
        }
    }
}