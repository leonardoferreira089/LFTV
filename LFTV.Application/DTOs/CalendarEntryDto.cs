namespace LFTV.Application.DTOs
{
    public class CalendarEntryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmissionId { get; set; }
        public DateTime CreatedAt { get; set; }

        public static CalendarEntryDto FromEntity(LFTV.Domain.Entities.CalendarEntry entity)
        {
            return new CalendarEntryDto
            {
                Id = entity.Id,
                Date = entity.Date,
                EmissionId = entity.EmissionId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}