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
    public class ScheduleController : ControllerBase
    {
        private static List<object> schedules = new List<object>();

        [HttpPost]
        public IActionResult CreateSchedule([FromBody] dynamic schedule)
        {
            schedules.Add(schedule);
            return Created("", schedule);
        }

        [HttpGet]
        public IActionResult GetSchedules()
        {
            return Ok(schedules);
        }
    }
}
