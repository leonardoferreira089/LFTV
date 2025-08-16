using LFTV.Domain.Entities;
using LFTV.Domain.Enums;
using LFTV.Domain.Interfaces;
using LFTV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LFTV.Infrastructure.Repositories
{
    namespace LFTV.Infrastructure.Repositories
    {
        public class EmissionRepository : Repository<Emission>, IEmissionRepository
        {
            public EmissionRepository(LFTVDbContext context) : base(context) { }

            public async Task<IEnumerable<Emission>> GetByJourAsync(DayOfWeekEnum jour)
            {
                return await _dbSet.Where(e => e.Jour == jour).ToListAsync();
            }

            public override async Task<Emission?> GetByIdAsync(int id)
            {
                return await _dbSet
                    .Include(e => e.ProgramContentId)
                    .FirstOrDefaultAsync(e => e.Id == id);
            }

            public override async Task<IEnumerable<Emission>> GetAllAsync()
            {
                return await _dbSet
                    .Include(e => e.ProgramContentId)
                    .ToListAsync();
            }
        }
    }
}