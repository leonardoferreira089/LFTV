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

namespace LFTV.Application.Commands.History
{
    public class UpdateHistoryCommandHandler : IRequestHandler<UpdateHistoryCommand>
    {
        private readonly LFTVContext _context;

        public UpdateHistoryCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateHistoryCommand request, CancellationToken cancellationToken)
        {
            var history = await _context.History
                                         .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (history == null)
            {
                throw new NotFoundException($"History with ID {request.Id} not found.");
            }

            history.ProgramId = request.ProgramId;
            history.WatchedDate = request.WatchedDate;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
