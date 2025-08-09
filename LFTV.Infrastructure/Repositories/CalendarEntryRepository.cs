using LFTV.Domain.Entities;
using LFTV.Domain.Interfaces;
using LFTV.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LFTV.Infrastructure.Repositories
{
    public class CalendarEntryRepository : Repository<CalendarEntry>, ICalendarEntryRepository
    {
        public CalendarEntryRepository(LFTVDbContext context) : base(context) { }

        public async Task<IEnumerable<CalendarEntry>> GetByMonthAsync(int year, int month)
        {
            return await _dbSet
                .Where(c => c.Jour == c.Jour)
                .ToListAsync();
        }
    }
}