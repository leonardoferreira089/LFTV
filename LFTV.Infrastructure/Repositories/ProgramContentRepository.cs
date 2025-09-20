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

        public async Task<IEnumerable<ProgramContent>> GetByEmissionSelectionIdAsync(int? emissionSelectionId)
        {
            if (emissionSelectionId == null)
                return await _dbSet.Where(pc => pc.EmissionSelectionId == null).ToListAsync();
            return await _dbSet.Where(pc => pc.EmissionSelectionId == emissionSelectionId).ToListAsync();
        }

    }
}