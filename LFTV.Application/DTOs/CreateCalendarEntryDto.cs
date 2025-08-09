using LFTV.Domain.Enums;

namespace LFTV.Application.DTOs
{
    public class CreateCalendarEntryDto
    {
        public DayOfWeekEnum Jour { get; set; }
        public int EmissionId { get; set; }
    }
}