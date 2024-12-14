using LFTV.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.History
{
    public class CreateHistoryCommandHandler : IRequestHandler<CreateHistoryCommand, int>
    {
        private readonly LFTVContext _context;

        public CreateHistoryCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateHistoryCommand request, CancellationToken cancellationToken)
        {
            var history = new LFTV.Domain.Entities.History
            {
                ProgramId = request.ProgramId,
                WatchedDate = request.WatchedDate
            };

            _context.History.Add(history);
            await _context.SaveChangesAsync(cancellationToken);

            return history.Id;  // Retourne l'ID de l'historique créé
        }
    }
}
