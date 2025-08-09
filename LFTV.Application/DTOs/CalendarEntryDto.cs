using LFTV.Domain.Enums;

namespace LFTV.Application.DTOs
{
    public class CalendarEntryDto
    {
        public int Id { get; set; }
        public DayOfWeekEnum Jour { get; set; }
        public int EmissionId { get; set; }
        public DateTime CreatedAt { get; set; }

        public static CalendarEntryDto FromEntity(LFTV.Domain.Entities.CalendarEntry entity)
        {
            return new CalendarEntryDto
            {
                Id = entity.Id,
                Jour = entity.Jour,
                EmissionId = entity.EmissionId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}