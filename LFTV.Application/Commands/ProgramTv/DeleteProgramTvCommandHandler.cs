using LFTV.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFTV.Application.Commands.ProgramTv
{
    public class DeleteProgramTvCommandHandler : IRequestHandler<DeleteProgramTvCommand>
    {
        private readonly LFTVContext _context;

        public DeleteProgramTvCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProgramTvCommand request, CancellationToken cancellationToken)
        {
            var programTv = await _context.TvPrograms.FindAsync(request.Id);
            if (programTv == null)
                throw new KeyNotFoundException("Program not found");

            _context.TvPrograms.Remove(programTv);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
