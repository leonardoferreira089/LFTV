using LFTV.Application.DTOs;

namespace LFTV.Application.Interfaces
{
    public interface ICalendarEntryService
    {
        Task<IEnumerable<CalendarEntryDto>> GetAllAsync();
        Task<CalendarEntryDto?> GetByIdAsync(int id);
        Task<IEnumerable<CalendarEntryDto>> GetByMonthAsync(int year, int month);
        Task<CalendarEntryDto> CreateAsync(CreateCalendarEntryDto dto);
        Task UpdateAsync(int id, UpdateCalendarEntryDto dto);
        Task DeleteAsync(int id);
    }
}