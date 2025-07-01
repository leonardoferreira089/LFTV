using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;
using LFTV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LFTV.Infrastructure.Repositories
{
    public class EmissionRepository : Repository<Emission>, IEmissionRepository
    {
        public EmissionRepository(LFTVDbContext context) : base(context) { }

        public async Task<IEnumerable<Emission>> GetByDateAsync(DateTime date)
        {
            return await _dbSet.Where(e => e.Date.Date == date.Date).ToListAsync();
        }
    }
}