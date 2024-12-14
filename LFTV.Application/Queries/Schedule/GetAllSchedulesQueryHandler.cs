using LFTV.Application.DTOs;
using LFTV.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Queries.Schedule
{
    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, List<ScheduleDTO>>
    {
        private readonly LFTVContext _context;

        public GetAllSchedulesQueryHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleDTO>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
        {
            var schedules = await _context.Schedules
                                          .ToListAsync(cancellationToken);

            return schedules.ConvertAll(schedule => new ScheduleDTO
            {
                Id = schedule.Id,
                Name = schedule.Name,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                Day = schedule.Day
            });
        }
    }
}
