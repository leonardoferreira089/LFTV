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
    public class UpdateProgramTvCommandHandler : IRequestHandler<UpdateProgramTvCommand>
    {
        private readonly LFTVContext _context;

        public UpdateProgramTvCommandHandler(LFTVContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProgramTvCommand request, CancellationToken cancellationToken)
        {
            var programTv = await _context.TvPrograms.FindAsync(request.Id);
            if (programTv == null)
                throw new KeyNotFoundException("Program not found");

            programTv.Name = request.Name;
            programTv.Description = request.Description;
            programTv.Type = request.Type;
            programTv.Category = request.Category;
            programTv.IsWatched = request.IsWatched;
            programTv.ImageUrl = request.ImageUrl;
            programTv.Link = request.Link;
            programTv.ScheduleId = request.ScheduleId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
