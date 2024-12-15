using LFTV.Application.Commands.ProgramTv;
using LFTV.Application.Queries.ProgramTv;
using LFTV.Domain.Entities;
using LFTV.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    public class ProgramTvController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramTvController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/ProgramTv
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProgramTvCommand command)
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
