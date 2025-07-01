using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;
using LFTV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LFTV.Infrastructure.Repositories
{
    public class ProgramContentRepository : Repository<ProgramContent>, IProgramContentRepository
    {
        public ProgramContentRepository(LFTVDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProgramContent>> GetByEmissionIdAsync(int emissionId)
        {
            return await _dbSet.Where(pc => pc.EmissionId == emissionId).ToListAsync();
        }
    }
}