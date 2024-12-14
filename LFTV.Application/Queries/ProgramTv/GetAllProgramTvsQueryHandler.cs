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

namespace LFTV.Application.Queries.ProgramTv
{
    public class GetAllProgramTvQueryHandler : IRequestHandler<GetAllProgramTvQuery, List<ProgramTvDTO>>
    {
        private readonly LFTVContext _context;

        public GetAllProgramTvQueryHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<List<ProgramTvDTO>> Handle(GetAllProgramTvQuery request, CancellationToken cancellationToken)
        {
            var programTvs = await _context.TvPrograms
                                           .Include(p => p.Schedule)  // Inclure Schedule si nécessaire
                                           .ToListAsync(cancellationToken);

            return programTvs.ConvertAll(programTv => new ProgramTvDTO
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
            });
        }
    }
}
