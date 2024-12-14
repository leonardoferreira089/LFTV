using LFTV.Application.DTOs;
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

namespace LFTV.Application.Queries.Schedule
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleDTO>
    {
        private readonly LFTVContext _context;

        public GetScheduleByIdQueryHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<ScheduleDTO> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _context.Schedules
                                         .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (schedule == null)
            {
                throw new NotFoundException($"Schedule with ID {request.Id} not found.");
            }

            return new ScheduleDTO
            {
                Id = schedule.Id,
                Name = schedule.Name,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                Day = schedule.Day
            };
        }
    }
}
