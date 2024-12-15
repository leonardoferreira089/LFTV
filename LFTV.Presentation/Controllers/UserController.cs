using LFTV.Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFTV.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
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
