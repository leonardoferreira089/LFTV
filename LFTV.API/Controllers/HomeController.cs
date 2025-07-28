using LFTV.Application.DTOs;
using LFTV.Application.Interfaces;
using LFTV.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

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
            var systemJour = DateTime.UtcNow.DayOfWeek; // System.DayOfWeek

            var emissions = await _emissionService.GetByJourAsync(systemJour);
            return Ok(emissions);
        }

        // GET: api/home/now
        [HttpGet("now")]
        public async Task<ActionResult<IEnumerable<EmissionDto>>> GetNowPlaying()
        {
            var now = DateTime.UtcNow;
            var systemJour = now.DayOfWeek;

            var emissions = await _emissionService.GetByJourAsync(systemJour);
            var current = emissions.Where(e =>
                e.StartTime <= now.TimeOfDay && e.EndTime > now.TimeOfDay
            ).ToList();
            return Ok(current);
        }

        private DayOfWeekEnum ConvertToLftvJour(DayOfWeek systemJour)
        {
            int value = systemJour == DayOfWeek.Sunday ? 7 : (int)systemJour;
            return (DayOfWeekEnum)value;
        }
    }
}