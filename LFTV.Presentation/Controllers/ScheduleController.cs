using LFTV.Application.Commands.Schedule;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFTV.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Schedule
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateScheduleCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), new { id = result }, result);
        }
    }
}
