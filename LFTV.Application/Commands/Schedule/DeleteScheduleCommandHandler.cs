using LFTV.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.Schedule
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand>
    {
        private readonly LFTVContext _context;

        public DeleteScheduleCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _context.Schedules
                                         .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (schedule == null)
            {
                throw new NotFoundException($"Schedule with ID {request.Id} not found.");
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
