using LFTV.Domain.Enums;

namespace LFTV.Application.DTOs
{
    public class UpdateCalendarEntryDto
    {
        public DayOfWeekEnum Jour { get; set; }
        
        public int EmissionId { get; set; }
    }
}