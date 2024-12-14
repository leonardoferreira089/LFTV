
using LFTV.Application.DTOs;
using LFTV.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Queries.ProgramTv
{
    public class GetProgramTvByIdQueryHandler : IRequestHandler<GetProgramTvByIdQuery, ProgramTvDTO>
    {
        private readonly LFTVContext _context;

        public GetProgramTvByIdQueryHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<ProgramTvDTO> Handle(GetProgramTvByIdQuery request, CancellationToken cancellationToken)
        {
            var programTv = await _context.TvPrograms
                                          .FindAsync(request.Id);

            if (programTv == null)
                throw new KeyNotFoundException("Program not found");

            return new ProgramTvDTO
            {
                Id = programTv.Id,
                Name = programTv.Name,
                Description = programTv.Description,
                Type = programTv.Type,
                Category = programTv.Category,
                IsWatched = programTv.IsWatched,
                ImageUrl = programTv.ImageUrl,
                Link = programTv.Link,
                ScheduleId = programTv.ScheduleId
            };
        }
    }
}
