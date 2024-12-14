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

namespace LFTV.Application.Queries.History
{
    public class GetAllHistoryQueryHandler : IRequestHandler<GetAllHistoryQuery, List<HistoryDTO>>
    {
        private readonly LFTVContext _context;

        public GetAllHistoryQueryHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<List<HistoryDTO>> Handle(GetAllHistoryQuery request, CancellationToken cancellationToken)
        {
            var histories = await _context.History
                                          .Include(h => h.Program)  // Inclure le programme associé
                                          .ToListAsync(cancellationToken);

            return histories.ConvertAll(history => new HistoryDTO
            {
                Id = history.Id,
                ProgramId = history.ProgramId,
                WatchedDate = history.WatchedDate,
            });
        }
    }
}
