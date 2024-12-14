using System;
using LFTV.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFTV.Infrastructure.Persistence;

namespace LFTV.Infrastructure.Repositories
{
    public class ProgramtvRepository : IProgramtvRepository
    {
        private readonly LFTVContext _context;

        public ProgramtvRepository(LFTVContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramTv>> GetAllProgramsAsync()
        {
            return await _context.TvPrograms.ToListAsync();
        }

        public async Task<ProgramTv> GetProgramByIdAsync(int id)
        {
            return await _context.TvPrograms.FindAsync(id);
        }

        public async Task AddProgramAsync(ProgramTv program)
        {
            await _context.TvPrograms.AddAsync(program);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgramAsync(ProgramTv program)
        {
            _context.TvPrograms.Update(program);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProgramAsync(int id)
        {
            var program = await _context.TvPrograms.FindAsync(id);
            if (program == null)
                return; 

            _context.TvPrograms.Remove(program);
            await _context.SaveChangesAsync();
        }
    }
}
