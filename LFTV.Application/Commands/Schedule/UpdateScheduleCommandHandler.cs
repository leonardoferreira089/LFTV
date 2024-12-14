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
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand>
    {
        private readonly LFTVContext _context;

        public UpdateScheduleCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _context.Schedules
                                         .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (schedule == null)
            {
                throw new NotFoundException($"Schedule with ID {request.Id} not found.");
            }

            schedule.Name = request.Name;
            schedule.StartTime = request.StartTime;
            schedule.EndTime = request.EndTime;
            schedule.Day = request.Day;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
