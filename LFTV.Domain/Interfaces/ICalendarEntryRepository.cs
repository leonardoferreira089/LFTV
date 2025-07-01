using LFTV.Domain.Entities;

namespace LFTV.Domain.Interfaces
{
    public interface ICalendarEntryRepository : IRepository<CalendarEntry>
    {
        Task<IEnumerable<CalendarEntry>> GetByMonthAsync(int year, int month);
    }
}