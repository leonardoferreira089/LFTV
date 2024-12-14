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

namespace LFTV.Application.Queries.History
{
    public class GetHistoryByIdQueryHandler : IRequestHandler<GetHistoryByIdQuery, HistoryDTO>
    {
        private readonly LFTVContext _context;

        public GetHistoryByIdQueryHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<HistoryDTO> Handle(GetHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var history = await _context.History
                                         .Include(h => h.Program)  // Inclure le programme associé
                                         .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (history == null)
            {
                throw new NotFoundException($"History with ID {request.Id} not found.");
            }

            return new HistoryDTO
            {
                Id = history.Id,
                ProgramId = history.ProgramId,
                WatchedDate = history.WatchedDate
            };
        }
    }
}
