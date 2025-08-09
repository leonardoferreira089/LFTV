using LFTV.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LFTV.Domain.Entities
{
    public class CalendarEntry
    {
        public int Id { get; set; }

        [Required]
        public DayOfWeekEnum Jour { get; set; }
        // Foreign Key
        public int EmissionId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public Emission Emission { get; set; } = null!;
    }
}