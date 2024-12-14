using LFTV.Infrastructure.Persistence;
using MediatR;
using LFTV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.ProgramTv
{
    public class CreateProgramTvCommandHandler : IRequestHandler<CreateProgramTvCommand, int>
    {
        private readonly LFTVContext _context;

        public CreateProgramTvCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProgramTvCommand request, CancellationToken cancellationToken)
        {
            var programTv = new LFTV.Domain.Entities.ProgramTv
            {
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                Category = request.Category,
                IsWatched = request.IsWatched,
                ImageUrl = request.ImageUrl,
                Link = request.Link,
                ScheduleId = request.ScheduleId
            };

            _context.TvPrograms.Add(programTv);
            await _context.SaveChangesAsync(cancellationToken);

            return programTv.Id;
        }
    }
}
