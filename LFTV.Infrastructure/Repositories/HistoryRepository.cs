using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;
using LFTV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LFTV.Infrastructure.Repositories
{
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {
        public HistoryRepository(LFTVDbContext context) : base(context) { }

        public async Task<IEnumerable<History>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(h => h.Program)
                .Where(h => h.UserId == userId)
                .ToListAsync();
        }
    }
}