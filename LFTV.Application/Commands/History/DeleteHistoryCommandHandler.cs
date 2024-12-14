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
    public class DeleteHistoryCommandHandler : IRequestHandler<DeleteHistoryCommand>
    {
        private readonly LFTVContext _context;

        public DeleteHistoryCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteHistoryCommand request, CancellationToken cancellationToken)
        {
            var history = await _context.History
                                         .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

            if (history == null)
            {
                throw new NotFoundException($"History with ID {request.Id} not found.");
            }

            _context.History.Remove(history);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
