using LFTV.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.Schedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {
        private readonly LFTVContext _context;

        public CreateScheduleCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new LFTV.Domain.Entities.Schedule
            {
                Name = request.Name,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Day = request.Day
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync(cancellationToken);

            return schedule.Id;  // Retourne l'ID du schedule créé
        }
    }
}
